using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuardians.Models.AccountViewModels
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [System.ComponentModel.DataAnnotations.EmailAddress]
        public string Email { get; set; }
    }
}
