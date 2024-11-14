using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Repositories.IUOW;
using HairSalon.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace HairSalon.Repositories.UOW
{
    public class FeedbackRepository : GenericRepository<Feedback>, IFeedbackRepository
    {
        protected readonly DatabaseContext _context;

        protected readonly DbSet<Feedback> _dbSet;

        public FeedbackRepository(DatabaseContext dbContext) : base(dbContext)
        {
            _context = dbContext;

            _dbSet = _context.Set<Feedback>();
        }
    }
}
