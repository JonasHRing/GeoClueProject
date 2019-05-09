using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GeoClueProject.Models.ViewModels
{
    public class HomeGameVM
    {
        public string[] ImageURL { get; set; }

        [Display(Name ="Country")]
        public SelectListItem[] CountryList { get; set; }

        [Range(1,3)]
        public int SelectedCountryValue { get; set; }

        public int Score { get; set; }

        public string Hint { get; set; }

        public string Username { get; set; }


        
    }


}
