using Leave_Management.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Leave_Management.Contracts
{
    public interface IEventsRepository : IRepositoryBase<Events>
    {
        void Add(Events newEvent);
    }
}
