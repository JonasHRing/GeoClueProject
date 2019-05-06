using GeoClueProject.Models.ViewModels;
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

        public Timer aTimer = new Timer();

        // har lagt denna metod i ApiService
        //public string correctCountry;

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

        public  void SetTimer()
        {

            int GuessTimeLimit = 3;
            for (int i = 0; i < GuessTimeLimit; i++)
                
            {
            Timer aTimer = new Timer();
                
            aTimer.Interval = 2000;
            aTimer.Enabled = true;

            }
           
        }

        // Specify what you want to happen when the Elapsed event is raised.
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Console.WriteLine("Hello World!");
        }

        public PlayerVM GetPlayerScore()
        {
            var player = new PlayerVM();
            player.Score += 20;
           
            return player;
        }
    }
}
