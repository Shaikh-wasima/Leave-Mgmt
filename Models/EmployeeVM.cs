using System;
using System.ComponentModel.DataAnnotations;

namespace Leave_Management.Models
{
    public class EmployeeVm
    {
        public string Id { get; set; }
        public string UserName { get; set; }
       
        public string PhoneNumber { get; set; }
        
        public string TaxId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateJoined { get; set; }
        public string Discriminator { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        public string Role { get; set; }



    }
}
