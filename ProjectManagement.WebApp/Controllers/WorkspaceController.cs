using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectManagement.WebApp.Data;
using ProjectManagement.WebApp.Models.Entities;
using ProjectManagement.WebApp.Models.Identity;
using ProjectManagement.WebApp.Models.ViewModels;

namespace ProjectManagement.WebApp.Controllers
{
    [Route("[controller]/[action]")]
    public class WorkspaceController(
        ILogger<WorkspaceController> logger,
        UserManager<AppUser> userManager,
        AppDbContext appDbContext) : Controller
    {

        [Authorize]
        [Route("/")]
        public async Task<IActionResult> Index()
        {
            AppUser user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException("");
            }

            List<ListProjectsViewModel> projectsOfUser = appDbContext.ProjectUserAssociations
                .Include(a => a.Project)
                .Where(a => a.UserId == user.Id)
                .Select(a => new ListProjectsViewModel()
                {
                    Id = a.Project.Id,
                    ProjectName = a.Project.ProjectName,
                    Description = a.Project.Description
                }).ToList();

            // gets projects list
            return View(projectsOfUser);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}