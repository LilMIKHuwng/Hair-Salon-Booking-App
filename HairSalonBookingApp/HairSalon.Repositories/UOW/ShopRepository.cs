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
    public class ShopRepository : GenericRepository<Shop>, IShopRepository
    {
        protected readonly DatabaseContext _context;

        protected readonly DbSet<Shop> _dbSet;

        public ShopRepository(DatabaseContext dbContext) : base(dbContext)
        {
            _context = dbContext;
            _dbSet = _context.Set<Shop>();
        }
    }
}
