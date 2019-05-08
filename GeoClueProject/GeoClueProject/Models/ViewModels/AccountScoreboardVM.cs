using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoClueProject.Models.ViewModels
{
    public class AccountScoreboardVM
    {
        public List<string> Users { get; set; }
        public List<int> Scores { get; set; }
    }
}
