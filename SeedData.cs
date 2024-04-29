using Leave_Management.Data;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace Leave_Management
{
    public class SeedData
    {

        private readonly ApplicationDbContext _context;
        public SeedData(
            RoleManager<UserRole> roleManager,
            UserManager<Employee> userManager,
            ApplicationDbContext context)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
            SeedLeaveTypes(context);
        }

        private void SeedUsers(UserManager<Employee> userManager)
        {
            var users = userManager.GetUsersInRoleAsync("Employee").Result;
            if (userManager.FindByNameAsync("admin@localhost.com").Result == null)
            {
                var user = new Employee
                {
                    UserName = "admin@localhost.com",
                    Email = "admin@localhost.com"
                };
                var result = userManager.CreateAsync(user, "P@ssword1").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }
        }

        private void SeedRoles(RoleManager<UserRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Administrator").Result)
            {
                var role = new UserRole
                {
                    Name = "Administrator"
                };

                var result = roleManager.CreateAsync(role).Result;
            }
            if (!roleManager.RoleExistsAsync("Employee").Result)
            {
                var role = new UserRole
                {
                    Name = "Employee"
                };

                var result = roleManager.CreateAsync(role).Result;
            }
        }
        private void SeedLeaveTypes(ApplicationDbContext context)
        {
            if (!context.LeaveTypes.Any())
            {
                var leaveTypes = new LeaveType[]
                {
                    new LeaveType { Name = "Annual Leave" },
                    new LeaveType { Name = "Sick Leave" },
                    new LeaveType { Name = "Maternity Leave" },
                    // Add more leave types as needed
                };
                context.LeaveTypes.AddRange(leaveTypes);
                context.SaveChanges();
            }
        }
    }
}
