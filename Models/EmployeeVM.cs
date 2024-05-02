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

        [Required]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[^\d]+$", ErrorMessage = "Name cannot contain numbers")]
        [Display(Name = "First Name")]
        public string Firstname { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[^\d]+$", ErrorMessage = "Name cannot contain numbers")]

        [Display(Name = "Last Name")]
        public string Lastname { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [MaxLength(50)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter a valid email address. It must be in the format: example@example.com")]
        public string Email { get; set; }

        public string Role { get; set; }


        public int ManagerId { get; set; }
        public AssignManagerVM Manager { get; set; }
    }





}

