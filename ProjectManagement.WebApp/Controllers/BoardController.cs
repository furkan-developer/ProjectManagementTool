using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using ProjectManagement.WebApp.Data;
using ProjectManagement.WebApp.Models;
using ProjectManagement.WebApp.Models.DTOs;
using ProjectManagement.WebApp.Models.Entities;
using ProjectManagement.WebApp.Models.ViewModels;

namespace ProjectManagement.WebApp.Controllers;

public class BoardController(AppDbContext appDbContext) : Controller
{
    // [Authorize]
    public IActionResult Index([FromQuery] Guid workspaceId)
    {
        // gets all boards by specified id of workspace
        var listBoardsVMs = appDbContext.Boards
            .Where(b => b.ProjectId == workspaceId)
            .Select(b => new ListBoardsViewModel { Id = b.Id, Title = b.Title })
            .ToList();

        return View(listBoardsVMs);
    }

    // [Authorize]
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
                }).ToList()
            })
            .ToList();

        return View(new GetDetailsOneBoardViewModel() { stageDtos = StageDtos, BoardId = boardId });
    }

    [HttpPost]
    public JsonResult UpdateStageOfOneTask([FromBody] UpdateStageOfOneTaskDto dto)
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

        var job = appDbContext.Jobs.AsTracking().SingleOrDefault(j => j.Id == dto.TaskId);
        job.StageId = dto.ToStage;

        appDbContext.SaveChanges();

        return Json(new { isSuccess = true });
    }


    [HttpGet]
    public IActionResult CreateOneTask(Guid stageId, Guid boardId)
    {
        TempData["BoardId"] = boardId;
        ViewData["StageId"] = stageId;

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult CreateOneTask([FromForm] CreateOneTaskViewModel createOneTaskViewModel)
    {
        // TODO: Your code here

        if (ModelState.IsValid)
        {
            appDbContext.Jobs.Add(new Job
            {
                Title = createOneTaskViewModel.Title,
                Description = createOneTaskViewModel.Description,
                DueDate = createOneTaskViewModel.DueDate,
                Priority = createOneTaskViewModel.Priority,
                StageId = createOneTaskViewModel.StageId,
                AssignedTo = "random-user",
                Status = "active"
            });
            appDbContext.SaveChanges();

            return RedirectToAction("GetDetailsOneBoard", new { boardId = TempData["BoardId"] });
        }

        return View(createOneTaskViewModel);
    }


    public IActionResult Privacy()
    {
        return View();
    }
}
