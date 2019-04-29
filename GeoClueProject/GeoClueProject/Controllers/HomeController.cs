using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeoClueProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace GeoClueProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("Game/Singleplayer")]
        public IActionResult Game()
        {
            return View();
        }

        public IActionResult Login()
        {
            return Content("Now you are at the login page");
        }

        public IActionResult Register()
        {
            return Content("Here is the page where you register");
        }

        [Route("")]
        public async Task<IActionResult> IndexAsync()
        {
            var helper = new ApiImage();
            var result = await helper.Search("United states of america");
            return Content(result);
        }

    }
}