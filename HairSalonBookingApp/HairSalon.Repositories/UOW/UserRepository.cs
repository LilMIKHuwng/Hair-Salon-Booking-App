using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Repositories.IUOW;
using HairSalon.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalon.Repositories.UOW
{
	public class UserRepository : GenericRepository<User>, IUserRepository
	{
		protected readonly DatabaseContext _context;

		protected readonly DbSet<User> _dbSet;

		public UserRepository(DatabaseContext dbContext) : base(dbContext)
		{
			_context = dbContext;
			_dbSet = _context.Set<User>();
		}
	}
}
