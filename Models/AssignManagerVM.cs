using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Leave_Management.Models
{
    public class AssignManagerVM
    {

        





        public List<EmployeeVm> Employees { get; set; }
        public List<EmployeeVm> Managers { get; set; }





    }
}