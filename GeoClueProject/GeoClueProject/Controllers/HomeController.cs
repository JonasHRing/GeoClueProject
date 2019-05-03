using System;
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
            var viewModel = await homeService.GetImageURL();
            return View(await homeService.GetRoot(viewModel));
        }

        [HttpPost]
        [Route("Game/Singleplayer/")]
        public IActionResult Game(string country)
        {
            
            homeService.SetTimer();

            //var root = await homeService.GetRoot(viewModel);

            //var selectedCountry = root.CountryList[viewModel.SelectedCountryValue].Text;
            Player player1 = new Player();


            if (country == homeService.correctCountry)
            {
                //player1.Score = HttpContext.Session.GetInt32("player1.Score").Value + 20;
                //HttpContext.Session.SetInt32("player1.Score", player1.Score);
                //player1.Score = HttpContext.Session.GetInt32("player1.Score").Value;

                player1.Score = Convert.ToInt32(HttpContext.Session.GetString("player1.Score")) + 20;
                HttpContext.Session.SetString("player1.Score", player1.Score.ToString());
                player1.Score = Convert.ToInt32(HttpContext.Session.GetString("player1.Score"));
                return PartialView("Right", player1);
            }
            else
                return PartialView("Wrong");
        }


        public IActionResult Login()
        {
            return View();
        }
        
        //[Route("Game/SinglePlayer")]
        //public async Task<IActionResult> Root()
        //{
        //    return View(await homeService.GetRoot());
        //}

        //[HttpGet]
        //[Route("/home/root")]
        //public async Task<IActionResult> Root()
        //{
        //    var test = homeService.RandomCountry();
        //    //var helper = new ApiCountry();
        //    //var result = await helper.CountryList();
        //    //var viewModel = new HomeGameVM { ImageURL = result };
        //    return Content(test );


        //}



        //[Route("")]
        //public async Task<IActionResult> IndexAsync()
        //{
        //    var helper = new ApiImage();
        //    var result = await helper.Search("India");
        //    return Content(result);
        //}


    }
}