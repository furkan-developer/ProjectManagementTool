using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.WebApp.Models;

namespace ProjectManagement.WebApp.Controllers;

public class BoardController : Controller
{
    private readonly ILogger<BoardController> _logger;

    public BoardController(ILogger<BoardController> logger)
    {
        _logger = logger;
    }

    // [Authorize]
    public IActionResult Index([FromQuery] Guid workspaceId)
    {
        // gets all boards by specified id of workspace
        ViewData["value"] = workspaceId;
        return View();
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

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
