using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetGuardians.Entities
{
    public class Offer
    {
        public Offer()
        {
            Added = DateTime.Now;
        }
        
        [Key]
        public int Id { get; set; }
        public string Town { get; set; }

        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public DateTime Added { get; set; }
        
        public DateTime From { get; set; }
        
        public DateTime To { get; set; }
        
        public int Price { get; set; }

        public ApplicationUser Owner { get; set; }
        public ICollection<ApplicationUser> Offers { get; set; }
    }
}
