using HairSalon.Core;
using HairSalon.ModelViews.ComboModelViews;
using HairSalon.ModelViews.PromotionModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalon.Contract.Services.Interface
{
    public interface IPromotionService
    {
        Task<string> AddPromotionAsync(CreatePromotionModelView model, string? userId); // Add userId
        Task<BasePaginatedList<PromotionModelView>> GetAllPromotionsAsync(int pageNumber, int pageSize, string? name, string? code); // Add filters
        Task<string> UpdatePromotionAsync(string promotionId, UpdatePromotionModelView model, string? userId); // Add userId
        Task<string> DeletePromotionAsync(string promotionId, string? userId); // Add userId
        Task<PromotionModelView?> GetPromotionByIdAsync(string promotionId);
		Task<List<PromotionModelView>> GetAllPromotionAsync();
	}
}
