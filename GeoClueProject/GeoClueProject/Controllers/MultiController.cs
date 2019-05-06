using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GeoClueProject.Controllers
{
    public class MultiController : Controller
    {
        public IActionResult Cluemaster()
        {
            return View();
        }
        public IActionResult Receiver()
        {
            return View();
        }
        public IActionResult Lobby()
        {
            return View();
        }
    }
}