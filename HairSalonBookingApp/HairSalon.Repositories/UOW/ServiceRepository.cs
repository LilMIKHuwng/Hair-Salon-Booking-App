using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Repositories.IUOW;
using HairSalon.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace HairSalon.Repositories.UOW
{
    public class ServiceRepository : GenericRepository<Service>, IServiceRepository
    {
        protected readonly DatabaseContext _context;

        protected readonly DbSet<Service> _dbSet;

        public ServiceRepository(DatabaseContext dbContext) : base(dbContext)
        {
            _context = dbContext;

            _dbSet = _context.Set<Service>();
        }
    }
}
