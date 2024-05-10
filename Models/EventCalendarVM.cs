using Leave_Management.Data;
using System;
using System.Collections.Generic;

namespace Leave_Management.Models
{
    public class EventCalendarVM
    {
        public IEnumerable<Events> EventsList { get; set; }

      


        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Employee RequestingEmployee { get; set; }
        
    }
}
