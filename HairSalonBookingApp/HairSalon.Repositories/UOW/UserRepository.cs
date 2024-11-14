using HairSalon.Contract.Repositories.IUOW;
using HairSalon.Repositories.Context;
using HairSalon.Repositories.Entity;
using Microsoft.EntityFrameworkCore;

namespace HairSalon.Repositories.UOW
{
	public class UserRepository : GenericRepository<ApplicationUsers>, IUserRepository
	{
		protected readonly DatabaseContext _context;

		protected readonly DbSet<ApplicationUsers> _dbSet;

		public UserRepository(DatabaseContext dbContext) : base(dbContext)
		{
			_context = dbContext;
			_dbSet = _context.Set<ApplicationUsers>();
		}
	}
}
