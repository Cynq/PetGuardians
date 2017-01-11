using PetGuardians.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuardians.Models.Guardian
{
    public class OfferVm
    {
        public int Id { get; set; }

        [Display(Name = "Temat")]
        [Required(ErrorMessage = "To pole jest wymagane!")]
        public string Name { get; set; }

        [Display(Name = "Opis")]
        [Required(ErrorMessage = "To pole jest wymagane!")]
        public string Description { get; set; }

        [Display(Name = "Kiedy dodano")]
        public DateTime Added { get; set; }

        [Display(Name = "Czas rozpoczęcia opieki")]
        [Required(ErrorMessage = "To pole jest wymagane!")]
        public DateTime From { get; set; }

        [Display(Name = "Czas zakończenia opieki")]
        [Required(ErrorMessage = "To pole jest wymagane!")]
        public DateTime To { get; set; }

        [Display(Name = "Cena za usługę (zł)")]
        [Required(ErrorMessage = "To pole jest wymagane!")]
        public int Price { get; set; }

        [Display(Name = "Miejscowość")]
        [Required(ErrorMessage = "To pole jest wymagane!")]
        public string Town { get; set; }

        public bool MyOffer { get; set; }

        public bool CanApply { get; set; }
        public bool CanRate { get; set; }
        public ApplicationUser Owner { get; internal set; }
    }
}
