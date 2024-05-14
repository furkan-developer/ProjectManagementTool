using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.WebApp.Data;
using ProjectManagement.WebApp.Models;
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
    public IActionResult GetDetailsOneBoard()
    {
        // gets information of specified board  
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
}
