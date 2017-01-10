using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using PetGuardians.Models.AccountViewModels;

namespace PetGuardians.Entities
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
    }
}
