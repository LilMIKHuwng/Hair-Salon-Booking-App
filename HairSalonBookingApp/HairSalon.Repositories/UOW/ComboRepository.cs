using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Repositories.IUOW;
using HairSalon.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace HairSalon.Repositories.UOW
{
    public class ComboRepository : GenericRepository<Combo>, IComboRepository
    {
        protected readonly DatabaseContext _context;

        protected readonly DbSet<Appointment> _dbSet;

        public ComboRepository(DatabaseContext dbContext) : base(dbContext)
        {
            _context = dbContext;

            _dbSet = _context.Set<Appointment>();
        }
    }
}
