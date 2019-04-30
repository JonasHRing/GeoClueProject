using System;
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

        //HomeService homeService;

        //public HomeController(HomeService homeService)
        //{
        //    this.homeService = homeService;
        //}

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("Game/Singleplayer")]
        public async Task<IActionResult> Game()
        {
            var helper = new ApiImage();
            var result = await helper.Search("China");
            var viewModel = new HomeGameVM { ImageURL = result };
            return View(viewModel);
        }

        [HttpPost]
        [Route("Game/Singleplayer")]
        public async Task<IActionResult> Game(HomeGameVM viewModelx)
        {
            var helper = new ApiImage();
            var result = await helper.Search("China");
            var viewModel = new HomeGameVM { ImageURL = result };
            return View(viewModel);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        [Route("/home/root")]
        public async Task<IActionResult> Root()
        {
            var helper = new ApiCountry();
            var result = await helper.CountryList();
            //var viewModel = new HomeGameVM { ImageURL = result };
            return Content(result[0]);
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