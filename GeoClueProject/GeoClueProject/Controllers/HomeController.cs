﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using GeoClueProject.Models;
using GeoClueProject.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GeoClueProject.Controllers
{
    public class HomeController : Controller
    {
        HomeService homeService;
        ApiService apiService;

        public HomeController(HomeService homeService, ApiService apiService)
        {
            this.homeService = homeService;
            this.apiService = apiService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("Game/Singleplayer")]
        public async Task<IActionResult> Game()
        {
            var viewModel = await apiService.GetImageURL();
            return View(await homeService.GetRoot(viewModel));
        }

        [HttpPost]
        [Route("Game/Singleplayer/")]
        public  IActionResult Game(string country)
        {
            
            //homeService.SetTimer();

            //var root = await homeService.GetRoot(viewModel);

            //var selectedCountry = root.CountryList[viewModel.SelectedCountryValue].Text;
            HomeGameVM player1 = new HomeGameVM();
            var correctAnswer = HttpContext.Session.GetString("correctCountry");

            if (country == correctAnswer)
            {
                player1.Score = Convert.ToInt32(HttpContext.Session.GetString("player1.Score")) + 20;
                HttpContext.Session.SetString("player1.Score", player1.Score.ToString());
                player1.Score = Convert.ToInt32(HttpContext.Session.GetString("player1.Score"));
                return PartialView("Right", player1);
            }
            else
            {
                return PartialView("Wrong");
            }
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}