using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Repositories.IUOW;
using HairSalon.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace HairSalon.Repositories.UOW
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    { 
        protected readonly DatabaseContext _context;

        protected readonly DbSet<Payment> _dbSet;

        public PaymentRepository(DatabaseContext dbContext) : base(dbContext)
        {
            _context = dbContext;

            _dbSet = _context.Set<Payment>();
        }
    }
}
