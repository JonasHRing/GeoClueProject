using GeoClueProject.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoClueProject.Models
{
    public class HomeService
    {
      
        public string correctCountry;
        
        public async Task<HomeGameVM> GetImageURL()
        {
            var helper = new ApiImage();
            var nameOfCountry = RandomCountry();
            var result = await helper.Search(nameOfCountry);
            correctCountry = nameOfCountry;

            return new HomeGameVM { ImageURL = result };

        }

        public async Task<HomeGameVM> GetRoot(HomeGameVM viewModel)
        {
            var helper = new ApiCountry();
            var result = await helper.GetCountryList();

            viewModel.CountryList = new SelectListItem[result.Length];

            for (int i = 0; i < result.Length; i++)
            {
                viewModel.CountryList[i] = new SelectListItem { Value = i.ToString(), Text = result[i] };
            }

            return viewModel;
        }

        public string RandomCountry()
        {
            var apiCountry = new ApiCountry();
            var countryList = apiCountry.GetCountryList();

            var rnd = new Random();
            var index = rnd.Next(15,18);
            var country = countryList.Result[index-1];

            return country;
        }
    }
}
