using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevTraining.BlazorServer.Contacts.Entities
{
    public class ContactResponseDTO
    {
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime? InActivatedDate { get; set; }
    }
}
