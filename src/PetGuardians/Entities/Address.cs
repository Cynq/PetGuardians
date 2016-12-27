using System.ComponentModel.DataAnnotations;

namespace PetGuardians.Entities
{
    public class Address
    {
        [Key]
        public int Id { get; set; }


        [StringLength(50, MinimumLength = 6)]
        [Required]
        public string Street { get; set; }

        [StringLength(20, MinimumLength = 2)]
        [Required]
        public string Town { get; set; }

        [StringLength(6)]
        [Required]
        public string PostNumber { get; set; }
    }
}

