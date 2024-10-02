using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Repositories.IUOW;
using HairSalon.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace HairSalon.Repositories.UOW
{
    public class ServiceRepository : GenericRepository<Service>, IServiceRepository
    {
        //Declare a variable to store the database context
        protected readonly DatabaseContext _context;

        // Declare a variable to store the TutorSubject collection in the database
        protected readonly DbSet<Service> _dbSet;

        // Constructor receives DatabaseContext and passes it to the base class through base
        public ServiceRepository(DatabaseContext dbContext) : base(dbContext)
        {
            // Assign the database context to the variable _context
            _context = dbContext;

            // Set up _dbSet to work with TutorSubject entities
            _dbSet = _context.Set<Service>();
        }
    }
}
