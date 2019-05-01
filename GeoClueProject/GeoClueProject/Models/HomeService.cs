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
        public async Task<HomeGameVM> GetImageURL()
        {
            var helper = new ApiImage();
            var result = await helper.Search(RandomCountry());
            return new HomeGameVM { ImageURL = result };

        }

        public async Task<HomeGameVM> GetRoot(HomeGameVM viewModel)
        {
            var helper = new ApiCountry();
            var result = await helper.CountryList();
            //var viewModel = new HomeGameVM()
            //{
            //    CountryList = new SelectListItem[] { new SelectListItem { Value = "1", Text = "Åland" }, new SelectListItem { Value = "2", Text = "Gotland" }, new SelectListItem { Value = "3", Text = "USA" }, }
            //};

            viewModel.CountryList = new SelectListItem[result.Length];

            for (int i = 0; i < result.Length; i++)
            {
                viewModel.CountryList[i] = new SelectListItem { Value = i.ToString(), Text = result[i] };
            }
           

            return viewModel;
        }


        public string RandomCountry()
        {
            var countries = new ApiCountry();
            var countryList = countries.CountryList();

            var rnd = new Random();
            var index = rnd.Next(countryList.Result.Length);
            var country = countryList.Result[index];
           
            return country;
            

        }


    }
}
