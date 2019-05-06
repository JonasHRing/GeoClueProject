using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GeoClueProject.Models.ViewModels;
using GeoClueProject.Models;
using Microsoft.AspNetCore.Authorization;

namespace GeoClueProject.Controllers
{
    public class AccountController : Controller
    {
        AccountService accountService;

        public AccountController(AccountService accountService)
        {
            this.accountService = accountService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(AccountRegisterVM viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            // Try to register user
            var result = await accountService.TryRegisterAsync(viewModel);
            if (!result.Succeeded)
            {
                // Show error
                ModelState.AddModelError(string.Empty, result.Errors.First().Description);
                return View(viewModel);
            }

            // Redirect user
            return RedirectToAction(nameof(Login));
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            return View(new AccountLoginVM { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(AccountLoginVM viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            // Check if credentials is valid (and set auth cookie)
            var result = await accountService.TryLoginAsync(viewModel);
            if (!result.Succeeded)
            {
                // Show error
                ModelState.AddModelError(nameof(AccountLoginVM.Username), "Login failed");
                return View(viewModel);
            }

            // Redirect user
            if (string.IsNullOrWhiteSpace(viewModel.ReturnUrl))
                return RedirectToAction(nameof(Welcome));
            else
                return Redirect(viewModel.ReturnUrl);
        }

        public IActionResult Welcome()
        {
            return View(new AccountWelcomeVM { Username = User.Identity.Name });
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await accountService.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Scoreboard()
        {
            var viewModel = await accountService.GetUsers();
            return View(viewModel);
        }
    }
}