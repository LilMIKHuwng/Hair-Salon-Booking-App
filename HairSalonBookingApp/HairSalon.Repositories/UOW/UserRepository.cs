using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Repositories.IUOW;
using HairSalon.Repositories.Context;
using HairSalon.Repositories.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalon.Repositories.UOW
{
	public class UserRepository : GenericRepository<ApplicationUser>, IUserRepository
	{
		protected readonly DatabaseContext _context;

		protected readonly DbSet<ApplicationUser> _dbSet;

		public UserRepository(DatabaseContext dbContext) : base(dbContext)
		{
			_context = dbContext;
			_dbSet = _context.Set<ApplicationUser>();
		}
	}
}
