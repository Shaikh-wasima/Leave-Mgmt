using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_Management.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        ILeaveTypeRepository LeaveType { get; }
        ILeaveRequestRepository LeaveRequest { get; }
        ILeaveAllocationRepository LeaveAllocation { get; }
        IEventsRepository Events { get; }
        void Save();
    }
}
