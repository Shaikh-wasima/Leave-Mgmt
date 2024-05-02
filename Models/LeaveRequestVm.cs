﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Leave_Management.Models
{
    public class LeaveRequestVm
    {
        public int Id { get; set; }
        public EmployeeVm RequestingEmployee { get; set; }
        [Display(Name = "Employee Name")]
        public string RequestingEmployeeId { get; set; }
        [Required]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Required]
        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public LeaveTypeVM LeaveType { get; set; }

        public int LeaveTypeId { get; set; }
        [Display(Name = "Date Requested")]
        public DateTime DateRequested { get; set; }
        [Display(Name = "Date Actioned")]
        public DateTime DateActioned { get; set; }
        [Display(Name = "Approval Status")]
        public bool? Approved { get; set; }
        public EmployeeVm ApprovedBy { get; set; }
        [Display(Name = "Approval Name")]
        public string ApprovedById { get; set; }
        public bool Cancelled { get; set; }
        [Display(Name = "Employee Comments")]
        [MaxLength(300)]
        public string RequestComments { get; set; }
        public int TotalDays => (int)(EndDate - StartDate).TotalDays + 1;

        public string RejectionMessage { get; set; }

    }

    public class CreateLeaveRequestVm
    {
        [Required]
        [Display(Name = "Start Date")]
        public string StartDate { get; set; }
        [Required]
        [Display(Name = "End Date")]
        public string EndDate { get; set; }
        public IEnumerable<SelectListItem> LeaveTypes { get; set; }

        [Required(ErrorMessage = "Please select a leave type")]
        [Display(Name = "Leave Type")]
        public int LeaveTypeId { get; set; }
        [Display(Name = "Employee Comments")]
        [MaxLength(300)]
        public string RequestComments { get; set; }

    }
    public class AdminLeaveRequestVm
    {
        [Display(Name = "Total No. of Requests")]
        public int TotalRequest { get; set; }
        [Display(Name = "Approved Requests")]

        public int ApprovedRequest { get; set; }

        [Display(Name = "Pending Requests")]
        public int PendingRequest { get; set; }

        [Display(Name = "Rejected Requests")]
        public int RejectedRequest { get; set; }
        public List<LeaveRequestVm> LeaveRequest { get; set; }
    }

    public class EmployeeLeaveRequestVm
    {
        public List<LeaveAllocationVm> LeaveAllocations { get; set; }
        public List<LeaveRequestVm> LeaveRequests { get; set; }
        public int TotalApprovedLeave { get; set; }
        public int TotalRejectedLeave { get; set; }
        public int TotalPendingLeave { get; set; }

    }
}
