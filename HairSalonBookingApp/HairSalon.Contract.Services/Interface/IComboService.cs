using HairSalon.Core;
using HairSalon.ModelViews.ComboModelViews;

namespace HairSalon.Contract.Services.Interface
{
    public interface IComboService
    {
        Task<string> CreateComboAsync(CreateComboModelView model);
        Task<BasePaginatedList<ComboModelView>> GetAllCombosAsync(int pageNumber, int pageSize, string? id, string? name);
        Task<string> UpdateComboAsync(string id, UpdateComboModelView model);
        Task<string> DeleteComboAsync(string id);
		Task<BasePaginatedList<StatisticalComboModelView>> GetStatisticalCombosAsync(int pageNumber, int pageSize, int? month, int? year);
	}
}
