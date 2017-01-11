using PetGuardians.Entities;
using System.Collections.Generic;

namespace PetGuardians.Models
{
    public class MessagesIndexVm
    {
        public IEnumerable<Message> Messages { get; set; }
        public string UserId { get; set; }
    }
}
