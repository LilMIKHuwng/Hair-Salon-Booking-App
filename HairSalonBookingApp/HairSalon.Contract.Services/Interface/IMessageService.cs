using HairSalon.Core;
using HairSalon.ModelViews.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalon.Contract.Services.Interface
{
    public interface IMessageService
    {
        
        Task<string> AddMessageAsync(CreateMessageViewModel model);

        Task<BasePaginatedList<MessageViewModel>> GetAllMessageAsync(int pageNumber, int pageSize);
        Task<MessageViewModel> GetMessageByIdAsync(string id);
    }

}
