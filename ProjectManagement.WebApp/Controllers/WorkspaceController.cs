using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ProjectManagement.WebApp.Controllers
{
    public class WorkspaceController : Controller
    {
        private readonly ILogger<WorkspaceController> _logger;

        public WorkspaceController(ILogger<WorkspaceController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // gets projects list
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}