using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;

namespace Leave_Management.Data
{
    public class Events
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("RequestingEmployeeId")]
        public Employee RequestingEmployee { get; set; }
        public string RequestingEmployeeId { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string Title { get; set; } = string.Empty;
        
    }
}
