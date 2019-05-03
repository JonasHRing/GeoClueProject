using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using GeoClueProject.Models;
using GeoClueProject.Models.ViewModels;
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

            if (country == apiService.correctCountry)
            {
                //return Content($"{country} {apiService.correctCountry}");
                var playerScore = homeService.GetPlayerScore();
                //playerScore = playerScore+20;
                return PartialView("Right", playerScore);
            }
            else
            {
                return PartialView("Wrong");
                //return Content($"{country} {apiService.correctCountry}");
            }

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