using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.WebApp.Data;
using ProjectManagement.WebApp.Models;
using ProjectManagement.WebApp.Models.DTOs;
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
                StageName = s.StageName,
                jobDTOs = s.Jobs.Select(j => new JobDTO(){
                    DueDate = j.DueDate,
                    Title = j.Title,
                    Priority = j.Priority,
                }).ToList()
            })
            .ToList();

        return View(new GetDetailsOneBoardViewModel(){stageDtos = StageDtos });
    }

    public IActionResult Privacy()
    {
        return View();
    }
}
