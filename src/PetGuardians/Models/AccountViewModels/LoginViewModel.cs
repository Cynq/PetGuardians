using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuardians.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="To pole jest wymagane!")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane!")]
        [Display(Name = "Hasło")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Zapamiętaj hasło")]
        public bool RememberMe { get; set; }
    }
}
