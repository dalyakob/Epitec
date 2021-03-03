using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevTraining.BlazorServer.Data.Entities
{
    public class ContactResponseDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Please Enter a Last Name")]
        [StringLength(50, ErrorMessage = "String Capacity 50 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please Enter a First Name")]
        [StringLength(50, ErrorMessage = "String Capacity 50 characters")]
        public string FirstName { get; set; }

        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid phone number.")]
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime? InActivatedDate { get; set; }
    }
}

