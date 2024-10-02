using HairSalon.Contract.Repositories.Entity;
using HairSalon.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace HairSalon.Repositories.UOW;

public class ServiceAppointmentRepository : GenericRepository<ServiceAppointment>
{
    protected readonly DatabaseContext _context;

    protected readonly DbSet<ServiceAppointment>? _dbSet;
    
    public ServiceAppointmentRepository(DatabaseContext dbContext) : base(dbContext)
    {
        _context = dbContext;

        _dbSet = _context.Set<ServiceAppointment>();
    }
}