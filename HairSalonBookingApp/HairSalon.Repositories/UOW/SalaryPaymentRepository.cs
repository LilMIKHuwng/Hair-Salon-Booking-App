using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Repositories.IUOW;
using HairSalon.Repositories.Context;

namespace HairSalon.Repositories.UOW
{
    public class SalaryPaymentRepository : GenericRepository<SalaryPayment>, ISalaryPaymentRepository
    {
        private readonly DatabaseContext _databaseContext;

        public SalaryPaymentRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
            _databaseContext = databaseContext;
        }
}
}
