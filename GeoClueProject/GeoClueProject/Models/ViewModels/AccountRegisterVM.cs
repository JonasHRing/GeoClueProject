using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GeoClueProject.Models.ViewModels
{
    public class AccountRegisterVM
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Repeat password")]
        [Compare(nameof(AccountRegisterVM.Password))]
        public string PasswordRepeat { get; set; }

        public int Score { get; set; }
    }
}
