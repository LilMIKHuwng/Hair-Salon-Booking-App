using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Repositories.IUOW;
using HairSalon.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace HairSalon.Repositories.UOW
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        protected readonly DatabaseContext _context;

        protected readonly DbSet<Appointment> _dbSet;

        public AppointmentRepository(DatabaseContext dbContext) : base(dbContext)
        {
            _context = dbContext;

            _dbSet = _context.Set<Appointment>();
        }
    }
}
