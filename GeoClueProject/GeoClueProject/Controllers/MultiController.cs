using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeoClueProject.Models;
using GeoClueProject.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GeoClueProject.Controllers
{
    public class MultiController : Controller
    {
        HomeService homeService;
        ImageService imageService;
        CountryService countryService;
        private readonly AccountService accountService;

        public MultiController(HomeService homeService, ImageService imageService, AccountService accountService, CountryService countryService)
        {
            this.homeService = homeService;
            this.imageService = imageService;
            this.accountService = accountService;
            this.countryService = countryService;
        }

        public async Task<IActionResult> Cluemaster()
        {
            var countryName =  await countryService.RandomCountryAsync();
            var viewModel = await imageService.GetImageURL(countryName);
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
            var countryName = await countryService.RandomCountryAsync();
            var viewModel = await imageService.GetImageURL(countryName);
            return View(await homeService.GetRoot(viewModel));
        }
        public IActionResult Lobby(int id)
        {
            var viewModel =accountService.GetPlayerList();
            return View(viewModel);
        }
       
    }
}