using AutoMapper;
using Leave_Management.Data;
using Leave_Management.Models;

namespace Leave_Management.Mapping
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<LeaveType, LeaveTypeVM>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestVm>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationVm>().ReverseMap();
            CreateMap<LeaveAllocation, EditLeaveAllocationVM>().ReverseMap();
            CreateMap<Employee, EmployeeVm>().ReverseMap();
            CreateMap<Events, EventCalendarVM>().ReverseMap();
            CreateMap<LeaveRequestVm, LeaveRequest>()
            .ForMember(dest => dest.RejectionMessage, opt => opt.MapFrom(src => src.RejectionMessage));
        }
    }
}
