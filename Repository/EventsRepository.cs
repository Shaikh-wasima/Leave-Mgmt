using Leave_Management.Contracts;
using Leave_Management.Data;

namespace Leave_Management.Repository
{
    public class EventsRepository : RepositoryBase<Events>, IEventsRepository
    {
        private readonly ApplicationDbContext _db;
        public EventsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

    }
}
