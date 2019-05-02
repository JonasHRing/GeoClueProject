using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        [Route("Game/Singleplayer")]
        public async Task<IActionResult> Game(HomeGameVM viewModel)
        {
            var root = await homeService.GetRoot(viewModel);
            var selectedCountry = root.CountryList[viewModel.SelectedCountryValue].Text;
            if (selectedCountry == homeService.correctCountry)
                return Content("Congrats! "+homeService.correctCountry+" is the correct country!");
            else
                return View(await homeService.GetImageURL());
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
       
        [HttpGet]
        public IActionResult ImageHint()
        {
            return PartialView("_ImageHint");
        }
    }
}