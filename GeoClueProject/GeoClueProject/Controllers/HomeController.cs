using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

    }
}