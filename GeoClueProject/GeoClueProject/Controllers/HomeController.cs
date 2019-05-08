﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using GeoClueProject.Models;
using GeoClueProject.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GeoClueProject.Controllers
{
    public class HomeController : Controller
    {
       
        HomeService homeService;
        ImageService imageService;
        CountryService countryService;
      
        private readonly AccountService accountService;

        public HomeController(HomeService homeService, AccountService accountService, ImageService imageService, CountryService countryService)
        {
            this.homeService = homeService;
            this.accountService = accountService;
            this.imageService = imageService;
            this.countryService = countryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("Game/Singleplayer")]
        public async Task<IActionResult> Game()
        {
            var countryName = countryService.RandomCountry();
            var viewModel = await imageService.GetImageURL(countryName);
            
            return View(await homeService.GetRoot(viewModel));
        }

        [HttpPost]
        [Route("Game/Singleplayer/")]
        public async Task<IActionResult> GameAsync(string country)
        {
            
            //homeService.SetTimer();

            //var root = await homeService.GetRoot(viewModel);

            //var selectedCountry = root.CountryList[viewModel.SelectedCountryValue].Text;
            HomeGameVM player1 = new HomeGameVM();
            var correctAnswer = HttpContext.Session.GetString("correctCountry");

            if (country == correctAnswer)
            {
                //player1.Score = Convert.ToInt32(HttpContext.Session.GetString("player1.Score")) + 20;
                //await accountService.HandleCorrectGuess(20);
                //HttpContext.Session.SetString("player1.Score", player1.Score.ToString());
                //player1.Score = Convert.ToInt32(HttpContext.Session.GetString("player1.Score"));
                //return PartialView("Right",player1);
                return Content($"{correctAnswer}{country}");
            }
            else
            {
                //return PartialView("Wrong");
                return Content($"{correctAnswer}{country}");
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

    }
}