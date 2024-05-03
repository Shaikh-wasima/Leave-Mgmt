using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace Leave_Management.Data
{
    public class UserRole : IdentityRole
    {

        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "Invalid Role Name. Please enter a valid role name containing only letters and spaces.")]
        public string Name { get; set; }


    }
}
