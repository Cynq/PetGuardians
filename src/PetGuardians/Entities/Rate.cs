using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetGuardians.Entities
{
    public class Rate
    {
        [Key]
        public int Id { get; set; }
        
        public ApplicationUser From { get; set; }
        public ApplicationUser To { get; set; }

        public int Value { get; set; }
    }
}