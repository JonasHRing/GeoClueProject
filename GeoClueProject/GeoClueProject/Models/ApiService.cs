using GeoClueProject.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoClueProject.Models
{
    public class ApiService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApiService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public HomeGameVM GetHint()
        {
            HomeGameVM homeGameVM = new HomeGameVM();
            homeGameVM.Hint = _httpContextAccessor.HttpContext.Session.GetString("correctCountry");
            return homeGameVM;
        }
        public async Task<HomeGameVM> GetImageURL()
        {
            var helper = new ApiImage();
            var nameOfCountry = RandomCountry();
            var result = await helper.Search(nameOfCountry);
            //correctCountry = nameOfCountry;
            _httpContextAccessor.HttpContext.Session.SetString("correctCountry", nameOfCountry);

            return new HomeGameVM { ImageURL = result };
        }

        public string RandomCountry()
        {
            var apiCountry = new ApiCountry();
            var countryList = apiCountry.GetCountryList();

            var rnd = new Random();
            var index = rnd.Next(15,18);
            var country = countryList.Result[index - 1];

            return country;
        }
    }
}
