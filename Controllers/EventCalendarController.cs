using Leave_Management.Contracts;
using Leave_Management.Data;
using Leave_Management.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Leave_Management.Controllers
{
    public class EventCalendarController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<Employee> _userManager;

        public EventCalendarController(IUnitOfWork unitOfWork, UserManager<Employee> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            
   

            

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> AddEvent([FromBody] EventCalendarVM model)
        {
            var claimsPrincipal = HttpContext.User;

            
            var userIdClaim = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier);
            var employee = await _userManager.FindByIdAsync(userIdClaim.Value);
            var employeeName = employee.Firstname + " " + employee.Lastname;
            
           

            if (ModelState.IsValid)
            {
                var newEvent = new Events
                {
                    Title = model.Title + " - " + employeeName,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    RequestingEmployeeId = userIdClaim.Value,
                    RequestingEmployee = employee,
                    
                };

                _unitOfWork.Events.Add(newEvent);
                _unitOfWork.Save();

                return RedirectToAction("Index","EventCalendar");
            }

            return BadRequest("Invalid event data.");
        }

        [HttpGet]
        public IActionResult GetEvents()
        {
            var events = _unitOfWork.Events.GetAll();

            return Json(events);
        }
    }

   
}