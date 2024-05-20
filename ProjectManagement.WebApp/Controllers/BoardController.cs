using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using ProjectManagement.WebApp.Data;
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
        List<StageDto> StageDtos = appDbContext.Stages
            .Where(s => s.BoardId == boardId)
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
                    Assignments = j.Users.Select(a => $"{a.User.FirstName} {a.User.LastName}").ToList()
                }).ToList()
            })
            .ToList();

        return View(new GetDetailsOneBoardViewModel() { stageDtos = StageDtos, BoardId = boardId });
    }

    [HttpPost]
    public async Task<JsonResult> UpdateStageOfOneTask([FromBody] UpdateStageOfOneTaskDto dto, [FromServices] UserManager<AppUser> userManager)
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

        return Json(new { isSuccess = true });
    }

    [HttpPost]
    public JsonResult DeleteOneTask([FromBody] DeleteOneTaskDTO dto)
    {
        var job = appDbContext.Jobs.SingleOrDefault(j => j.Id == dto.JobId);
        if (job is null)
            return Json(new { isSuccess = false, errorMessage = "Task is not available" });

        appDbContext.Jobs.Remove(job);
        appDbContext.SaveChanges();

        return Json(new { isSuccess = true });
    }


    [HttpGet]
    public IActionResult CreateOneTask(Guid boardId, Guid stageId, string? returnUrl)
    {
        ViewData["StageId"] = stageId;
        if (returnUrl is not null)
        {
            TempData["ReturnUrl"] = returnUrl;
            ViewData["ReturnUrl"] = returnUrl;
        }

        List<UserAssignmentViewModel> users = appDbContext.BoardUserAssociations
          .Where(a => a.BoardId == boardId)
          .Include(a => a.AppUser)
          .Select(a => new UserAssignmentViewModel()
          {
              Id = a.AppUser.Id,
              FullName = $"{a.AppUser.FirstName} {a.AppUser.LastName}"
          }).ToList();

        var viewModel = new CreateOneTaskViewModel() { Assignments = users };

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult CreateOneTask([FromForm] CreateOneTaskViewModel createOneTaskViewModel)
    {
        if (ModelState.IsValid)
        {
            createOneTaskViewModel.Assignments = createOneTaskViewModel.Assignments.Where(a => a.IsChecked).ToList();

            appDbContext.Jobs.Add(new Job
            {
                Title = createOneTaskViewModel.Title,
                Description = createOneTaskViewModel.Description,
                DueDate = createOneTaskViewModel.DueDate,
                Priority = createOneTaskViewModel.Priority,
                StageId = createOneTaskViewModel.StageId,
                Users = createOneTaskViewModel.Assignments
                    .Select(a =>
                        new JobUserAssociation() { UserId = a.Id }
                    ).ToList()
            });

            appDbContext.SaveChanges();

            var returnUrl = TempData["ReturnUrl"];
            if (returnUrl != null)
            {
                TempData.Remove("ReturnUrl");
                return Redirect(returnUrl.ToString() ?? "/");
            }
            return RedirectToAction("Index", "Workspace");
        }

        return View(createOneTaskViewModel);
    }

    [HttpGet]
    public IActionResult CreateOneBoard([FromQuery] Guid workspaceId, [FromQuery] string returnUrl)
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


        var viewModel = new CreateOneBoardViewModel();
        viewModel.Assignments = appDbContext.ProjectUserAssociations
            .Where(a => a.ProjectId == workspaceId)
            .Select(a => new UserAssignmentViewModel()
            {
                Id = a.UserId,
                FullName = $"{a.User.FirstName} {a.User.LastName}"
            }).ToList();

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
}
