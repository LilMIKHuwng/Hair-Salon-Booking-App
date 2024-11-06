using HairSalon.Core;
using HairSalon.ModelViews.ComboModelViews;

namespace HairSalon.Contract.Services.Interface
{
    public interface IComboService
    {
        Task<string> CreateComboAsync(CreateComboModelView model, string? userId);
        Task<BasePaginatedList<ComboModelView>> GetAllCombosAsync(int pageNumber, int pageSize, string? id, string? name);
        Task<string> UpdateComboAsync(string id, UpdateComboModelView modeln, string? userId);
        Task<string> DeleteComboAsync(string id, string? userId);
        Task<ComboModelView?> GetComboByIdAsync(string id);
		Task<List<ComboModelView>> GetAllComboAsync();
	}
}
