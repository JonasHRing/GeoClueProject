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
<<<<<<< HEAD
            
            homeService.SetTimer();

            //var root = await homeService.GetRoot(viewModel);

            //var selectedCountry = root.CountryList[viewModel.SelectedCountryValue].Text;

            if (country == homeService.correctCountry)
                return PartialView("Right");
            else
                return PartialView("Wrong");
=======
            var root = await homeService.GetRoot(viewModel);
            var selectedCountry = root.CountryList[viewModel.SelectedCountryValue].Text;
            if (selectedCountry == homeService.correctCountry)
                return Content("Congrats! "+homeService.correctCountry+" is the correct country!");
            else
                return View(await homeService.GetImageURL());
>>>>>>> parent of e79b176... commit old backup
        }


        [HttpGet]
        public IActionResult GetHint1()
        {
            return PartialView("_GetHint1",homeService.GetImageURL());
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