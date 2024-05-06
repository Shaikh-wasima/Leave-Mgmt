using AutoMapper;
using Leave_Management.Contracts;
using Leave_Management.Data;
using Leave_Management.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Leave_Management.Controllers
{

   
    public class EventCalendarController : Controller
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;


        public EventCalendarController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _uow = unitOfWork;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
     
            return View();
        }
    }
}
