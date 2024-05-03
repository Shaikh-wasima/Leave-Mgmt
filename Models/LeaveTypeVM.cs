using System;
using System.ComponentModel.DataAnnotations;

namespace Leave_Management.Models
{
    public class LeaveTypeVM
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "Invalid Leave Type. Please enter a valid leave type name containing only letters.")]
        public string Name { get; set; }

        [Display(Name = "Default Number of Days")]
        [Required]
        [Range(1, 25, ErrorMessage = "Please Enter a Valid Number")]
        public int DefaultDays { get; set; }
        [Display(Name = "Date Created")]
        public DateTime? DateCreated { get; set; }
    }
}
