using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevTraining.Core.Models
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime? InActivatedDate { get; set; }
        public void InActivate()
        {
            InActivatedDate = DateTime.UtcNow;
            IsActive = false;
        }
    }

}
