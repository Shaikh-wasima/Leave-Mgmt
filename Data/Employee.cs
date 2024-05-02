using Microsoft.AspNetCore.Identity;
using System;

namespace Leave_Management.Data
{
    public class Employee : IdentityUser
    {

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string TaxId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateJoined { get; set; }
        public string Discriminator { get; set; }
        public string ManagerId { get; set; }
        public string ManagerName { get; set; }

    }
}
