using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetGuardians.Entities;

namespace PetGuardians.Models
{
    public class MyOfferDeailsVm
    {
        public Offer Offer { get; set; }
        public List<ApplicationUser> Applied { get; set; }
    }
}
