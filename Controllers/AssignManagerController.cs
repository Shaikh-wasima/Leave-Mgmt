using AutoMapper;
using Leave_Management.Data;
using Leave_Management.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_Management.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AssignManagerController : Controller
    {
        private readonly UserManager<Employee> _userManager;
        private readonly RoleManager<UserRole> _roleManager;
        private readonly IMapper _mapper;

        public AssignManagerController(UserManager<Employee> userManager, RoleManager<UserRole> roleManager, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            //var employees = _userManager.GetUsersInRoleAsync("Employee").Result;
            //var employeeVmList = employees.Select(e => new EmployeeVm
            //{
            //    Id = e.Id,
            //    Email = e.Email,
            //    Firstname = e.Firstname,
            //    Lastname = e.Lastname
            //}).ToList();

            //return View(employeeVmList);
            return View();
        }






        //private List<EmployeeVm> GetEmployeeVmList()
        //{
        //    var employees = _userManager.GetUsersInRoleAsync("Employee").Result;
        //    return employees.Select(e => new EmployeeVm
        //    {
        //        Id = e.Id,
        //        Email = e.Email,
        //        Firstname = e.Firstname,
        //        Lastname = e.Lastname
        //    }).ToList();
        //}







        public async Task<IActionResult> EmployeeWithManager()
        {
            var allRoles = _roleManager.Roles.ToList();
            var employeesWithRoles = new List<EmployeeVm>();

            foreach (var role in allRoles)
            {
                var usersInRole = await _userManager.GetUsersInRoleAsync(role.Name);
                var roleName = role.Name.ToLower(); // Assuming role names are plural

                var roleEmployees = _mapper.Map<List<EmployeeVm>>(usersInRole);
                roleEmployees.ForEach(e => e.Role = roleName);

                // Populate manager information for each employee
                foreach (var employee in roleEmployees)
                {
                    var managerId = employee.ManagerId; // Assuming you have manager ID stored in EmployeeVm
                    var manager = await _userManager.FindByIdAsync((managerId).ToString());
                    employee.Manager = _mapper.Map<AssignManagerVM>(manager);
                }

                employeesWithRoles.AddRange(roleEmployees);
            }

            return View(employeesWithRoles);
        }

    }
}

