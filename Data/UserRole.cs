using Microsoft.AspNetCore.Identity;

namespace Leave_Management.Data
{
    public class UserRole : IdentityRole
    {
        
        public string Name { get; set; }
    }
}
