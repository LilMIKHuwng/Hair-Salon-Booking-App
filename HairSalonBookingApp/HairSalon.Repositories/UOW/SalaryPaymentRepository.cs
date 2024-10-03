using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Repositories.IUOW;
using HairSalon.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace HairSalon.Repositories.UOW
{
    public class SalaryPaymentRepository : GenericRepository<SalaryPayment>, ISalaryPaymentRepository
    {
        private readonly DatabaseContext _databaseContext;

		protected readonly DbSet<SalaryPayment> _dbSet;

		public SalaryPaymentRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
            _databaseContext = databaseContext;

			_dbSet = _context.Set<SalaryPayment>();
		}
}
}
