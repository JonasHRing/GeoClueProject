﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeoClueProject.Models;
using GeoClueProject.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace GeoClueProject.Controllers
{
    public class HomeController : Controller
    {
        

        HomeService homeService;

        public HomeController(HomeService homeService)
        {
            this.homeService = homeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("Game/Singleplayer")]
        public async Task<IActionResult> Game()
        {

            var a = new HomeService();
            var test =await a.GetImageURL();

            var helper = new ApiImage(); // lägg i helper class
            var result = await helper.Search("India");// lägg i helper class
            var viewModel = new HomeGameVM { ImageURL = result };
            return View(viewModel);
            return View(await homeService.GetImageURL());
        }

        [HttpPost]
        [Route("Game/Singleplayer")]
        public async Task<IActionResult> Game(HomeGameVM viewModelx)
        {

            return View(await homeService.GetImageURL());


        }

        public IActionResult Login()
        {
            return View();
        }



        //[Route("")]
        //public async Task<IActionResult> IndexAsync()
        //{
        //    var helper = new ApiImage();
        //    var result = await helper.Search("India");
        //    return Content(result);
        //}


    }
}