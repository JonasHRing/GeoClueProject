using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GeoClueProject.Models.ViewModels
{
    public class AccountScoreboardVM
    {
        public List<string> Users { get; set; }
        public List<int> Scores { get; set; }

        [Display(Name = "Player")]
        public SelectListItem[] PlayerList { get; set; }

        [Range(1, 3)]
        public int SelectedPlayerValue { get; set; }

    }
}
