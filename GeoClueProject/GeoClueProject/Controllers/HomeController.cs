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
            var result = await helper.Search("United states of america");
            var viewModel = new HomeGameVM { ImageURL = result };
            return View(viewModel);
        }

        [HttpPost]
        [Route("Game/Singleplayer")]
        public async Task<IActionResult> Game(HomeGameVM viewModelx)
        {
            var helper = new ApiImage();
            var result = await helper.Search("United states of america");
            var viewModel = new HomeGameVM { ImageURL = result };
            return View(viewModel);
        }

        public IActionResult Login()
        {
            return View();
        }


        [Route("")]
        public async Task<IActionResult> GameAsync()
        {
            var helper = new ApiImage();
            var result = await helper.Search("United states of america");
            return Content(result);
        }


        //[Route("")]
        //public async Task<IActionResult> IndexAsync()
        //{
        //    var helper = new ApiImage();
        //    var result = await helper.Search("United states of america");
        //    return Content(result);
        //}


    }
}