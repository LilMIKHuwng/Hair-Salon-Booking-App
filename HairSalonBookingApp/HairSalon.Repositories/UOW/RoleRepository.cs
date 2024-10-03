using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Repositories.IUOW;
using HairSalon.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace HairSalon.Repositories.UOW
{
    public class RoleRepository : GenericRepository<ApplicationRoles>, IRoleRepository
    {
        private readonly DatabaseContext _dbContext;

		protected readonly DbSet<ApplicationRoles> _dbSet;

		public RoleRepository(DatabaseContext context) : base(context)
        {
            _dbContext = context;

			_dbSet = _context.Set<ApplicationRoles>();
		}
    }
}
