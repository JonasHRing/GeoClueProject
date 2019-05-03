using GeoClueProject.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoClueProject.Models
{
    public class ApiService
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
        public string RandomCountry()
        {
            var apiCountry = new ApiCountry();
            var countryList = apiCountry.GetCountryList();

            var rnd = new Random();
            var index = rnd.Next(15, 18);
            var country = countryList.Result[index - 1];

            return country;

        }

        ////public bool Correctcountry()
        ////{
        ////    if(country == correctCountry)
        ////}
    }
}
