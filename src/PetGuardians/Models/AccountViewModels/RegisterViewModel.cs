using System.ComponentModel.DataAnnotations;
using PetGuardians.Entities;

namespace PetGuardians.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "To pole jest wymagane!")]
        [StringLength(50, ErrorMessage = "To pole musi posiadać od {2} do {1} znaków.", MinimumLength = 2)]
        [Display(Name = "Imię")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane!")]
        [StringLength(50, ErrorMessage = "To pole musi posiadać od {2} do {1} znaków.", MinimumLength = 2)]
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "To pole jest wymagane!")]
        [Display(Name = "Numer kontaktowy")]
        [StringLength(9, ErrorMessage = "To pole musi posiadać 9 cyfr np: 784554112")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane!")]
        [EmailAddress(ErrorMessage = "Pole {0} jest niepoprawnie uzupełnione")]
        [Display(Name = "Adres email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane!")]
        [StringLength(100, ErrorMessage = "To pole musi posiadać conajmniej {2} znaków.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Powtórz hasło")]
        [Compare("Password", ErrorMessage = "Podane hasła muszą do siebie pasować.")]
        public string ConfirmPassword { get; set; }
        
        [StringLength(50, ErrorMessage = "To pole musi posiadać od {2} do {1} znaków.", MinimumLength = 6)]
        [Required(ErrorMessage = "To pole jest wymagane!")]
        [Display(Name = "Ulica i numer")]
        public string Street { get; set; }

        [StringLength(20, ErrorMessage = "To pole musi posiadać od {2} do {1} znaków.", MinimumLength = 2)]
        [Required(ErrorMessage = "To pole jest wymagane!")]
        [Display(Name = "Miasto")]
        public string Town { get; set; }

        [StringLength(6, ErrorMessage = "To pole musi posiadać 6 znaków.")]
        [Required(ErrorMessage = "To pole jest wymagane!")]
        [Display(Name = "Kod pocztowy")]
        public string PostNumber { get; set; }

    }
}
