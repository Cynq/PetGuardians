using System.Collections.Generic;
using PetGuardians.Entities;
using PetGuardians.Models.AccountViewModels;

namespace PetGuardians.Models.Guardian
{
    public class MyOffersVm
    {
        public List<Offer> Offers { get; set; }
        public UserType UserType { get; set; }
    }
}
