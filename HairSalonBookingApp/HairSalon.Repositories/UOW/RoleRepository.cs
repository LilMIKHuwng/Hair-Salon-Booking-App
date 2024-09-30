using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Repositories.IUOW;
using HairSalon.Repositories.Context;

namespace HairSalon.Repositories.UOW
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        private readonly DatabaseContext _dbContext;

        public RoleRepository(DatabaseContext context) : base(context)
        {
            _dbContext = context;
        }
    }
}
