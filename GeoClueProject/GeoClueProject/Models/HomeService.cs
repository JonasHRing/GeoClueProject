using GeoClueProject.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoClueProject.Models
{
    public class HomeService
    {
        public async Task<HomeGameVM> GetImageURL()
        {
            var helper = new ApiImage();
            var result = await helper.Search("India");
            return new HomeGameVM { ImageURL = result };

        }

        public async Task<HomeGameVM> GetRoot()
        {
            var helper = new ApiImage();
            var result = await helper.Search("India");
            return new HomeGameVM { ImageURL = result };
        }
    }
}
