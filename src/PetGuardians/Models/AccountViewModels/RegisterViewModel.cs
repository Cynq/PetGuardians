using System.ComponentModel.DataAnnotations;

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
        [StringLength(50, ErrorMessage = "To pole musi posiadać od {2} do {1} znaków.", MinimumLength = 6)]
        [Display(Name = "Adres")]
        public string Address { get; set; }

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

        [Display(Name = "Typ konta")]
        [Required(ErrorMessage = "To pole jest wymagane!")]
        public UserType UserType { get; set; }
    }

    public enum UserType
    {
        [Display(Name = "Właściciel")]
        Owner,
        [Display(Name = "Opiekun")]
        Guardian
    }
}
