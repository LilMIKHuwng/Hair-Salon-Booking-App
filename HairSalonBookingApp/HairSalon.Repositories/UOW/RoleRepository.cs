using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Repositories.IUOW;
using HairSalon.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace HairSalon.Repositories.UOW
{
    public class RoleRepository : GenericRepository<ApplicationRole>, IRoleRepository
    {
        private readonly DatabaseContext _dbContext;

		protected readonly DbSet<ApplicationRole> _dbSet;

		public RoleRepository(DatabaseContext context) : base(context)
        {
            _dbContext = context;

			_dbSet = _context.Set<ApplicationRole>();
		}
    }
}
