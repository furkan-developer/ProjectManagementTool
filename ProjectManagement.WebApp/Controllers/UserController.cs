using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectManagement.WebApp.Models.Identity;
using ProjectManagement.WebApp.Models.ViewModels;

namespace ProjectManagement.WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(SignUpViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    UserName = viewModel.UserName,
                    Email = viewModel.Email,
                    Gender = viewModel.Gender,
                    BirthDay = viewModel.BirthDay,
                    CreatedOn = DateTime.UtcNow,
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                };

                var result = await _userManager.CreateAsync(user, viewModel.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                result.Errors.ToList().ForEach(f => ModelState.AddModelError(string.Empty, f.Description));
            }
            return View(viewModel);
        }

        public IActionResult Login(string? returnUrl)
        {
            if (returnUrl != null)
            {
                TempData["ReturnUrl"] = returnUrl;
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(SignInViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(viewModel.Email);
                if (user != null)
                {
                    await _signInManager.SignOutAsync();

                    var result = await _signInManager.PasswordSignInAsync(user, viewModel.Password, viewModel.RememberMe, true);

                    if (result.Succeeded)
                    {
                        await _userManager.ResetAccessFailedCountAsync(user);
                        await _userManager.SetLockoutEndDateAsync(user, null);

                        var returnUrl = TempData["ReturnUrl"];
                        if (returnUrl != null)
                        {
                            return Redirect(returnUrl.ToString() ?? "/");
                        }
                        return RedirectToAction("Index", "Admin");
                    }
                    else if (result.IsLockedOut)
                    {
                        var lockoutEndUtc = await _userManager.GetLockoutEndDateAsync(user);
                        var timeLeft = lockoutEndUtc.Value - DateTime.UtcNow;
                        ModelState.AddModelError(string.Empty, $"This account has been locked out, please try again {timeLeft.Minutes} minutes later.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid e-mail or password.");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid e-mail or password.");
                }
            }
            return View(viewModel);
        }
        public async Task Logout() => await _signInManager.SignOutAsync();

        public async Task ClaimsPrincipalExample()
        {
            var licenceClaims = new List<Claim>
            {
                new(ClaimTypes.Name, "Burak"),
                new("LicenceType", "B"),
                new("ValidUntil", "2022-09"),
            };

            var passportClaims = new List<Claim>
            {
                new(ClaimTypes.Name, "Burak"),
                new("ValidUntil", "2042-07"),
                new(ClaimTypes.Country, "Turkey")
            };

            var licenceIdentity = new ClaimsIdentity(licenceClaims, "LicenceIdentity");
            var passportIdentity = new ClaimsIdentity(passportClaims, "PassportIdentity");

            var userPrincipal = new ClaimsPrincipal(new[] { licenceIdentity, passportIdentity });

            var authenticationProperties = new AuthenticationProperties { IsPersistent = true };

            await HttpContext.SignInAsync(userPrincipal, authenticationProperties);
        }
    }
}