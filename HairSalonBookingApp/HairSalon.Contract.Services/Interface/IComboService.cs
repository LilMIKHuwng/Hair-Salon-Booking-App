using HairSalon.Core;
using HairSalon.ModelViews.ComboModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalon.Contract.Services.Interface
{
    public interface IComboService
    {
        Task<string> CreateComboAsync(CreateComboModelView model);
        Task<BasePaginatedList<ComboModelView>> GetAllCombosAsync(int pageNumber, int pageSize, string? id);
        Task<string> UpdateComboAsync(string id, UpdateComboModelView model);
        Task<string> DeleteComboAsync(string id);
    }
}
