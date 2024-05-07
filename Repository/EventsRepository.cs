using Leave_Management.Contracts;
using Leave_Management.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_Management.Repository
{
    public class EventsRepository : RepositoryBase<Events>, IEventsRepository
    {
        private readonly ApplicationDbContext _db;
        public EventsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Add(Events entity)
        {
            // Implement the logic to add the 'Events' entity to the database
            _db.Events.Add(entity);
        }



    }

}
