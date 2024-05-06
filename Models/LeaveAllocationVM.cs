using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Leave_Management.Models
{
    public class LeaveAllocationVm
    {
        public int Id { get; set; }
        public int NumberOfDays { get; set; }
        public DateTime DateCreated { get; set; }
        public int Period { get; set; }
        public EmployeeVm Employee { get; set; }
        public string EmployeeId { get; set; }
        public LeaveTypeVM LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public IEnumerable<SelectListItem> Employees { get; set; }
        public IEnumerable<SelectListItem> LeaveTypes { get; set; }



    }

    public class CreateLeaveAllocationVM
    {
        public int NumberUpdated { get; set; }
        public List<LeaveTypeVM> LeaveTypes { get; set; }
    }

    public class EditLeaveAllocationVM
    {
        public int Id { get; set; }
        [Required]
        [Range(0, 25, ErrorMessage = "Please Enter a Valid Number")]
        public int NumberOfDays { get; set; }
        public string EmployeeId { get; set; }
        public EmployeeVm Employee { get; set; }
        public LeaveTypeVM LeaveType { get; set; }

    }
    public class ViewLeaveAllocationVM
    {
        public EmployeeVm Employee { get; set; }
        public string EmployeeId { get; set; }
        public List<LeaveAllocationVm> LeaveAllocationVms { get; set; }





    }

}
