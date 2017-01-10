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
            Offers = new HashSet<ApplicationUser>();
        }
        
        [Key]
        public int Id { get; set; }
        [Display(Name = "miasto")]
        public string Town { get; set; }

        [Display(Name = "nazwa")]
        public string Name { get; set; }

        [Display(Name = "opis")]
        public string Description { get; set; }

        [Display(Name = "data dodania")]
        public DateTime Added { get; set; }

        [Display(Name = "początek")]
        public DateTime From { get; set; }

        [Display(Name = "koniec")]
        public DateTime To { get; set; }

        [Display(Name = "cena")]
        public int Price { get; set; }

        public ApplicationUser Owner { get; set; }
        public ICollection<ApplicationUser> Offers { get; set; }
        public bool Invisible { get; set; }
    }
}
