using GeoClueProject.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace GeoClueProject.Models
{
    public class HomeService
    {
        CountryService countryService;

        public HomeService(IHttpContextAccessor httpContextAccessor, CountryService countryService)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.countryService = countryService;
        }

        public Timer aTimer = new Timer();
        private readonly IHttpContextAccessor httpContextAccessor;

        // har lagt denna metod i ApiService
        //public string correctCountry;

        public async Task<HomeGameVM> GetRoot(HomeGameVM viewModel)
        {
           var result = await countryService.GetCountryList();

            viewModel.CountryList = new SelectListItem[result.Length];

            for (int i = 0; i < result.Length; i++)
            {
                viewModel.CountryList[i] = new SelectListItem { Value = i.ToString(), Text = result[i] };
            }

            return viewModel;
        }

        public async  void SetTimer()
        {
            Timer aTimer = new Timer();
            aTimer.Interval = 2000;
            aTimer.Enabled = true;
            //aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        }

        // Specify what you want to happen when the Elapsed event is raised.
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Console.WriteLine("Hello World!");
        }


    }
}
