using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Identity.Client;
using ProjectManagement.WebApp.Data;
using ProjectManagement.WebApp.Hubs;
using ProjectManagement.WebApp.Models;
using ProjectManagement.WebApp.Models.DTOs;
using ProjectManagement.WebApp.Models.Entities;
using ProjectManagement.WebApp.Models.Identity;
using ProjectManagement.WebApp.Models.ViewModels;

namespace ProjectManagement.WebApp.Controllers;

[Route("[controller]/[action]")]
public class BoardController(AppDbContext appDbContext) : Controller
{
    [Authorize]
    public IActionResult Index([FromQuery] Guid workspaceId)
    {
        // TODO: Bind workspaceId parameter to route-data
        ViewData["WorkspaceId"] = workspaceId;
        var project = appDbContext.Projects.SingleOrDefault(p => p.Id == workspaceId);
        if (project == null)
            return RedirectToAction("Index", "Workspace");

        ViewData["WorkspaceName"] = project.ProjectName;

        // gets all boards by specified id of workspace
        var listBoardsVMs = appDbContext.Boards
            .Where(b => b.ProjectId == workspaceId)
            .Select(b => new ListBoardsViewModel { Id = b.Id, Title = b.Title })
            .ToList();

        return View(listBoardsVMs);
    }

    [Authorize]
    public IActionResult GetDetailsOneBoard([FromQuery] Guid boardId)
    {
        var board = appDbContext.Boards.SingleOrDefault(b => b.Id == boardId);
        ViewData["WorkspaceId"] = board.ProjectId;

        List<StageDto> StageDtos = appDbContext.Stages
            .Where(s => s.BoardId == boardId)
            .OrderBy(s => s.CreatedOn)
            .Select(s => new StageDto()
            {
                StageId = s.Id,
                StageName = s.StageName,
                JobDTOs = s.Jobs.Select(j => new JobDTO()
                {
                    JobId = j.Id,
                    DueDate = j.DueDate,
                    Title = j.Title,
                    Priority = j.Priority,
                    Assignments = j.Users.Select(a => $"{a.User.FirstName} {a.User.LastName}").ToList(),
                    IsComplete = j.IsComplete
                }).ToList()
            })
            .ToList();

        return View(new GetDetailsOneBoardViewModel() { stageDtos = StageDtos, BoardId = boardId, BoardName = board.Title });
    }

    [HttpPost]
    public async Task<JsonResult> UpdateStageOfOneTask(
        [FromBody] UpdateStageOfOneTaskDto dto,
        [FromServices] UserManager<AppUser> userManager,
        [FromServices] IHubContext<GetDetailsOneBoardHub> getDetailsOneBoardHubContext)
    {
        appDbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

        var fromStage = appDbContext.Stages.SingleOrDefault(s => s.Id == dto.FromStage);
        var toStage = appDbContext.Stages.SingleOrDefault(s => s.Id == dto.ToStage);
        if (fromStage is null || toStage is null)
            return Json(new { isSuccess = false, errorMessage = "Stage is not available" });

        var hasJobAtStage = appDbContext.Stages
           .Include(s => s.Jobs)
           .Any(s => s.Id == dto.FromStage && s.Jobs.Where(j => j.Id == dto.TaskId).Any());

        if (!hasJobAtStage)
            return Json(new { isSuccess = false, errorMessage = "Task is not available" });

        if (User.IsInRole("project-user"))
        {
            AppUser user = await userManager.GetUserAsync(User);
            if (!(user != null && appDbContext.JobUserAssociations.Any(a => a.UserId == user.Id && a.JobId == dto.TaskId)))
                return Json(new { isSuccess = false, errorMessage = "You have not assignment for this task. Nonetheless, you don't perform any action over the task." });
        }

        var job = appDbContext.Jobs.AsTracking().SingleOrDefault(j => j.Id == dto.TaskId);
        job.StageId = dto.ToStage;
        appDbContext.SaveChanges();

        bool hasConnectionId = Request.Headers.TryGetValue("hub-connection-id", out var hubConnectionId);
        // if (!hasConnectionId)
        //     return Json(new { isSuccess = false, errorMessages = "Stage of task has updated successfully. however, please refresh to page" });

        await getDetailsOneBoardHubContext.Clients
            .AllExcept(hubConnectionId)
            .SendAsync("UpdateStageOfTask", new
            {
                fromStage = dto.FromStage,
                toStage = dto.ToStage,
                taskId = dto.TaskId
            });

        return Json(new { isSuccess = true });
    }

    [HttpPost]
    public async Task<JsonResult> DeleteOneTask(
        [FromBody] DeleteOneTaskDTO dto,
        [FromServices] IHubContext<GetDetailsOneBoardHub> getDetailsOneBoardHubContext)
    {
        var job = appDbContext.Jobs.SingleOrDefault(j => j.Id == dto.JobId);
        if (job is null)
            return Json(new { isSuccess = false, errorMessage = "Task is not available" });

        appDbContext.Jobs.Remove(job);
        appDbContext.SaveChanges();

        bool hasConnectionId = Request.Headers.TryGetValue("hub-connection-id", out var hubConnectionId);
        // if (!hasConnectionId)
        //     return Json(new { isSuccess = false, errorMessages = "Stage of task has updated successfully. however, please refresh to page" });

        await getDetailsOneBoardHubContext.Clients
            .AllExcept(hubConnectionId)
            .SendAsync("DeleteOneTask", new
            {
                taskId = job.Id,
            });

        return Json(new { isSuccess = true });
    }


    // [Authorize(Roles = "project-manager")]
    [HttpGet]
    public async Task<IActionResult> CreateOneBoardAsync([FromQuery] Guid workspaceId, [FromQuery] string returnUrl, [FromServices] UserManager<AppUser> userManager)
    {
        if (!(workspaceId == null || workspaceId == Guid.Empty))
            ViewData["WorkspaceId"] = workspaceId;
        else
            return RedirectToAction("Index", "Workspace");

        if (returnUrl is not null)
        {
            TempData["ReturnUrl"] = returnUrl;
            ViewData["ReturnUrl"] = returnUrl;
        }

        var user = await userManager.GetUserAsync(User);

        var viewModel = new CreateOneBoardViewModel();
        var allUsersAtProject = appDbContext.ProjectUserAssociations
            .Where(a => a.ProjectId == workspaceId)
            .Select(a => new UserAssignmentViewModel()
            {
                Id = a.UserId,
                FullName = $"{a.User.FirstName} {a.User.LastName}"
            }).ToList();

        var filterUsersAtProject = allUsersAtProject.FindAll(u => u.Id != user.Id);
        viewModel.Assignments = filterUsersAtProject;

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult CreateOneBoard([FromForm] CreateOneBoardViewModel createOneBoardViewModel)
    {
        if (ModelState.IsValid)
        {
            appDbContext.Boards.Add(new Board()
            {
                // TODO: Add description property. To do that first of all, add new column in database whose name will be 
                Title = createOneBoardViewModel.Title,
                ProjectId = createOneBoardViewModel.WorkspaceId,
                Users = createOneBoardViewModel.Assignments
                            .Where(a => a.IsChecked)
                            .Select(a => new BoardUserAssociation()
                            {
                                AppUserId = a.Id,
                            }).ToList(),
                Stages = createOneBoardViewModel.Stages
                    .Select(s => new Stage()
                    {
                        StageName = s.StageName,
                        Description = s.Description
                    }).ToList()
            });

            appDbContext.SaveChanges();

            var returnUrl = TempData["ReturnUrl"];
            if (returnUrl != null)
            {
                return Redirect(returnUrl.ToString() ?? "/");
            }
            return RedirectToAction("Index", "Workspace");
        }

        return View(createOneBoardViewModel);
    }

    // [Authorize(Roles = "project-user,project-manager")]
    [HttpGet("{jobId:guid}")]
    public async Task<IActionResult> GetDetailsOneTask([FromRoute] Guid jobId, string? returnUrl, [FromServices] UserManager<AppUser> userManager)
    {
        appDbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

        var user = await userManager.GetUserAsync(User);
        if (user == null)
        {
            if (returnUrl != null)
                return Redirect(returnUrl.ToString() ?? "/");
            return RedirectToAction(nameof(WorkspaceController.Index));
        }
        if (User.IsInRole("project-user"))
        {
            bool hasTask = appDbContext.JobUserAssociations.Any(a => a.UserId == user.Id && a.JobId == jobId);
            if (!hasTask)
            {
                Guid boardId = appDbContext.Jobs
                    .Include(j => j.Stage)
                    .ThenInclude(s => s.Board)
                    .SingleOrDefault(j => j.Id == jobId).Stage.BoardId;

                return RedirectToAction(nameof(GetDetailsOneBoard), new { BoardId = boardId });
            }
        }

        var job = appDbContext.Jobs.SingleOrDefault(j => j.Id == jobId);
        if (job == null)
            return View(null);

        var comments = appDbContext.Comments
            .Include(c => c.Sender)
            .Where(c => c.JobId == job.Id)
            .OrderBy(c => c.CreatedOn).ToList();
        var listCommentViewModel = new List<ListCommentViewModel>();
        if (comments is not null)
        {
            listCommentViewModel = comments.Select(c => new ListCommentViewModel
            {
                Content = c.Content,
                hasAssignmentToCurrentUser = c.SenderId == user.Id ? true : false,
                FromUser = $"{c.Sender.FirstName} {c.Sender.LastName}"
            }).ToList();
        }

        var listSubJobsViewModel = appDbContext.SubJobs
            .Where(s => s.JobId == jobId)
            .Select(s => new ListSubTaskViewModel { Id = s.Id, Title = s.Title, IsComplete = s.IsComplete })
            .OrderByDescending(s => s.IsComplete == true)
            .ToList();

        var viewModel = new GetDetailsOneTaskViewModel()
        {
            Title = job.Title,
            Description = job.Description,
            StartDate = job.StartDate,
            DueDate = job.DueDate,
            JobId = job.Id,
            Comments = listCommentViewModel,
            SubJobs = listSubJobsViewModel,
            IsComplete = job.IsComplete,
        };
        return View(viewModel);
    }


    [HttpPost]
    public async Task<JsonResult> HasAssignmentAgainstTask([FromBody] CheckAssignmentJobDTO dto, [FromServices] UserManager<AppUser> userManager)
    {
        var user = await userManager.GetUserAsync(User);
        if (user == null)
            return Json(new { isSuccess = false, errorMessage = "The user not found" });
        if (User.IsInRole("project-user"))
        {

            bool hasAssociation = appDbContext.JobUserAssociations.Where(a => a.UserId == user.Id && a.JobId == dto.JobId).Any();
            if (!hasAssociation)
                return Json(new { isSuccess = false });
        }


        return Json(new { isSuccess = true });
    }

    [HttpPost]
    // [Authorize(Roles = "project-manager,project-user")]
    public async Task<JsonResult> PostComment(
        [FromBody] CreateCommentDTO dto,
        [FromServices] UserManager<AppUser> userManager,
        [FromServices] IHubContext<CommentHub> commentHubContext)
    {
        if (ModelState.IsValid)
        {
            var user = await userManager.GetUserAsync(User);

            appDbContext.Comments.Add(new Comment
            {
                Content = dto.Content,
                JobId = dto.ToJob,
                SenderId = user.Id
            });
            appDbContext.SaveChanges();

            bool hasConnectionId = Request.Headers.TryGetValue("hub-connection-id", out var hubConnectionId);
            if (!hasConnectionId)
                return Json(new { isSuccess = false, errorMessages = "the comment has delivered successfully. however, please refresh to page" });


            await commentHubContext.Clients
                .AllExcept(hubConnectionId)
                .SendAsync("RecieveComment", new
                {
                    content = dto.Content,
                    fullName = $"{user.FirstName} {user.LastName}"
                });

            return Json(new { isSuccess = true });
        }

        var errorMessages = new List<string>();
        foreach (var modelState in ModelState.Values)
            foreach (var error in modelState.Errors)
                errorMessages.Add(error.ErrorMessage);

        return Json(new { isSuccess = false, errorMessages = errorMessages });
    }

    [HttpPost]
    public async Task<JsonResult> CreateOneSubTask(
        [FromBody] CreateOneSubTaskViewModel viewModel,
        [FromServices] IHubContext<CommentHub> commentHubContext)
    {
        if (ModelState.IsValid)
        {
            var hasCurrentTitle = appDbContext.SubJobs.Where(s => s.JobId == viewModel.TaskId).Any(s => s.Title.Equals(viewModel.Title));
            if (hasCurrentTitle)
                return Json(new { isSuccess = false, errorMessages = "There is sub task which has same title" });

            var subJob = new SubJob()
            {
                Title = viewModel.Title,
                IsComplete = viewModel.IsComplete,
                JobId = viewModel.TaskId,
            };

            appDbContext.SubJobs.Add(subJob);
            appDbContext.SaveChanges();

            bool hasConnectionId = Request.Headers.TryGetValue("hub-connection-id", out var hubConnectionId);
            // if (!hasConnectionId)
            //     return Json(new { isSuccess = false, errorMessages = "Stage of task has updated successfully. however, please refresh to page" });

            await commentHubContext.Clients
                .AllExcept(hubConnectionId)
                .SendAsync("CreateOneSubTask", new
                {
                    id = subJob.Id,
                    title = subJob.Title,
                    isComplete = subJob.IsComplete,
                    jobId = subJob.JobId
                });

            return Json(new { isSuccess = true, subTaskId = subJob.Id });
        }

        var errorMessages = new List<string>();
        foreach (var modelState in ModelState.Values)
            foreach (var error in modelState.Errors)
                errorMessages.Add(error.ErrorMessage);

        return Json(new { isSuccess = false, errorMessages = errorMessages });
    }

    [HttpPut]
    public IActionResult UpdateOneSubTaskStatus([FromHeader] Guid subTaskId)
    {
        bool hasSubjob = appDbContext.SubJobs.Any(s => s.Id == subTaskId);
        if (!hasSubjob)
            return Json(new { isSuccess = false, errorMessages = "There is no avaliable the task" });

        var subJob = appDbContext.SubJobs.SingleOrDefault(s => s.Id == subTaskId);
        subJob.IsComplete = !subJob.IsComplete;
        appDbContext.SaveChanges();

        return Json(new { isSuccess = true });
    }

    [HttpDelete]
    public async Task<JsonResult>  DeleteOneSubTask(
        [FromHeader] Guid subTaskId,
        [FromServices] IHubContext<CommentHub> commentHubContext)
    {
        bool hasSubjob = appDbContext.SubJobs.Any(s => s.Id == subTaskId);
        if (!hasSubjob)
            return Json(new { isSuccess = false, errorMessages = "There is no avaliable the task" });

        int effectedRowsNumber = appDbContext.SubJobs.Where(s => s.Id == subTaskId).ExecuteDelete();
        if (!(effectedRowsNumber > 0))
            return Json(new { isSuccess = false, errorMessages = "Delete process is failed. Again after time" });


        bool hasConnectionId = Request.Headers.TryGetValue("hub-connection-id", out var hubConnectionId);
        // if (!hasConnectionId)
        //     return Json(new { isSuccess = false, errorMessages = "Stage of task has updated successfully. however, please refresh to page" });

        await commentHubContext.Clients
            .AllExcept(hubConnectionId)
            .SendAsync("DeleteOneSubTask", new
            {
                subtaskId = subTaskId
            });

        return Json(new { isSuccess = true });
    }

    [HttpPost]
    public async Task<JsonResult> CreateOneStage(
        [FromBody] CreateOneStageViewModel viewModel,
        [FromServices] IHubContext<GetDetailsOneBoardHub> getDetailsOneBoardHubContext)
    {

        if (ModelState.IsValid)
        {
            bool hasSameStageName = appDbContext.Stages.Where(s => s.BoardId == viewModel.BoardId).Any(s => s.StageName.Equals(viewModel.StageName));
            if (hasSameStageName)
                return Json(new { isSuccess = false, errorMessages = "There is stage which has same name" });

            var stage = new Stage { StageName = viewModel.StageName, BoardId = viewModel.BoardId, Description = "STAGE DESCRIPTION" };
            appDbContext.Add(stage);
            appDbContext.SaveChanges();

            bool hasConnectionId = Request.Headers.TryGetValue("hub-connection-id", out var hubConnectionId);
            // if (!hasConnectionId)
            //     return Json(new { isSuccess = false, errorMessages = "Stage of task has updated successfully. however, please refresh to page" });

            await getDetailsOneBoardHubContext.Clients
                .AllExcept(hubConnectionId)
                .SendAsync("CreateOneStage", new
                {
                    boardId = viewModel.BoardId,
                    stageId = stage.Id,
                    stageName = viewModel.StageName,
                });

            return Json(new
            {
                isSuccess = true,
                data = new
                {
                    boardId = viewModel.BoardId,
                    stageId = stage.Id,
                    stageName = viewModel.StageName,
                }
            });
        }

        var errorMessages = new List<string>();
        foreach (var modelState in ModelState.Values)
            foreach (var error in modelState.Errors)
                errorMessages.Add(error.ErrorMessage);

        return Json(new { isSuccess = false, errorMessages = errorMessages });
    }

    [HttpGet("{boardId:guid}")]
    public JsonResult GetUsersAt([FromRoute] Guid boardId)
    {
        List<UserAssignmentViewModel> users = appDbContext.BoardUserAssociations
         .Where(a => a.BoardId == boardId)
         .Include(a => a.AppUser)
         .Select(a => new UserAssignmentViewModel()
         {
             Id = a.AppUser.Id,
             FullName = $"{a.AppUser.FirstName} {a.AppUser.LastName}"
         }).ToList();

        // var viewModel = new CreateOneTaskViewModel() { Assignments = users };
        return Json(new { isSuccess = true, users = users });
    }

    [HttpPost]
    public async Task<JsonResult> CreateOneTask(
        [FromBody] CreateOneTaskVM viewModel,
        [FromServices] IHubContext<GetDetailsOneBoardHub> getDetailsOneBoardHubContext)
    {
        if (ModelState.IsValid)
        {
            // TODO: Check whether there is task which has same name

            var job = new Job()
            {
                Title = viewModel.Title,
                Description = viewModel.Description,
                Priority = viewModel.Priority,
                DueDate = viewModel.DueDate,
                Users = viewModel.Assignments.Select(a => new JobUserAssociation
                {
                    UserId = a
                }).ToList(),
                StageId = viewModel.StageId
            };
            appDbContext.Jobs.Add(job);
            appDbContext.SaveChanges();

            var userNames = appDbContext.JobUserAssociations
                .Where(a => a.JobId == job.Id)
                .Include(a => a.User)
                .Select(a => $"{a.User.FirstName} {a.User.LastName}")
                .ToList();

            bool hasConnectionId = Request.Headers.TryGetValue("hub-connection-id", out var hubConnectionId);
            // if (!hasConnectionId)
            //     return Json(new { isSuccess = false, errorMessages = "Stage of task has updated successfully. however, please refresh to page" });

            await getDetailsOneBoardHubContext.Clients
                .AllExcept(hubConnectionId)
                .SendAsync("AddNewTaskToStage", new
                {
                    id = job.Id,
                    title = job.Title,
                    description = job.Description,
                    dueDate = job.DueDate,
                    assignments = userNames,
                    stageId = job.StageId,
                    priority = job.Priority
                });

            return Json(new
            {
                isSuccess = true,
                data = new
                {
                    id = job.Id,
                    title = job.Title,
                    description = job.Description,
                    dueDate = job.DueDate,
                    assignments = userNames,
                    stageId = job.StageId,
                    priority = job.Priority
                }
            });
        }

        var errorMessages = new List<string>();
        foreach (var modelState in ModelState.Values)
            foreach (var error in modelState.Errors)
                errorMessages.Add(error.ErrorMessage);

        return Json(new { isSuccess = false, errorMessages = errorMessages });
    }

    [HttpPut]
    public async Task<JsonResult> UpdateTaskStatus(
        [FromHeader] Guid taskId,
        [FromServices] IHubContext<GetDetailsOneBoardHub> getDetailsOneBoardHubContext)
    {
        var task = appDbContext.Jobs.Include(j => j.Stage).SingleOrDefault(j => j.Id == taskId);
        if (task is null)
            return Json(new { isSuccess = false, errorMessages = "The task is not available" });

        task.IsComplete = !task.IsComplete;
        appDbContext.SaveChanges();


        bool hasConnectionId = Request.Headers.TryGetValue("hub-connection-id", out var hubConnectionId);
        // if (!hasConnectionId)
        //     return Json(new { isSuccess = false, errorMessages = "Stage of task has updated successfully. however, please refresh to page" });

        await getDetailsOneBoardHubContext.Clients
            .All
            .SendAsync("UpdateIsCompleteTaskIcon", new
            {
                taskId = task.Id
            });



        return Json(new { isSuccess = true, data = new { isComplete = task.IsComplete } });
    }

}
