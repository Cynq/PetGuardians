using System;
using System.ComponentModel.DataAnnotations;

namespace PetGuardians.Entities
{
    public class Message
    {
        public int Id { get; set; }

        [Display(Name = "treść")]
        public string Body { get; set; }
        [Display(Name = "od")]
        public ApplicationUser From { get; set; }
        [Display(Name = "do")]
        public ApplicationUser To { get; set; }
        [Display(Name = "data wysłania")]
        public DateTime SentTime { get; set; }
    }
}
