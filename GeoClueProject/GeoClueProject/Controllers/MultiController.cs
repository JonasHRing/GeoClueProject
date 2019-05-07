using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeoClueProject.Models;
using GeoClueProject.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeoClueProject.Controllers
{
    public class MultiController : Controller
    {
        HomeService homeService;
        ApiService apiService;
        private readonly AccountService accountService;

        public MultiController(HomeService homeService, ApiService apiService, AccountService accountService)
        {
            this.homeService = homeService;
            this.apiService = apiService;
            this.accountService = accountService;
        }

        public async Task<IActionResult> Cluemaster()
        {
            var viewModel = await apiService.GetImageURL();
            return View(await homeService.GetRoot(viewModel));
        }

        public IActionResult GameAsync(string country)
        {

            HomeGameVM player1 = new HomeGameVM();
            var correctAnswer = HttpContext.Session.GetString("correctCountry");

            if (country == correctAnswer)
            {
                return Content("Correct");
            }
            else
            {
                return Content("Wrong");
            }
        }

        public async Task<IActionResult> Receiver()
        {
            var viewModel = await apiService.GetImageURL();
            return View(await homeService.GetRoot(viewModel));
        }
        public IActionResult Lobby()
        {
            return View();
        }
    }
}