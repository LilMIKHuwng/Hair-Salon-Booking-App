using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalon.Contract.Repositories.IUOW
{
    public interface IMessageRepository : IGenericRepository<Message>
    {
    }
}
