using AutoMapper;
using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Repositories.Interface;
using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.ModelViews.PromotionModelViews;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalon.Services.Service
{
    public class PromotionService : IPromotionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;

        public PromotionService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor contextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
        }

        // Lấy danh sách khuyến mãi với phân trang và bộ lọc
        public async Task<BasePaginatedList<PromotionModelView>> GetAllPromotionsAsync(int pageNumber, int pageSize, string? name, string? code)
        {
            IQueryable<Promotion> promotionQuery = _unitOfWork.GetRepository<Promotion>().Entities
                .AsNoTracking()
                .Where(p => !p.DeletedTime.HasValue);

            if (!string.IsNullOrWhiteSpace(name))
                promotionQuery = promotionQuery.Where(p => p.Name.Contains(name));

            if (!string.IsNullOrWhiteSpace(code))
                promotionQuery = promotionQuery.Where(p => p.Id == code);

            promotionQuery = promotionQuery.OrderByDescending(p => p.CreatedTime);

            int totalCount = await promotionQuery.CountAsync();

            List<Promotion> paginatedPromotions = await promotionQuery
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            List<PromotionModelView> promotionModelViews = _mapper.Map<List<PromotionModelView>>(paginatedPromotions);

            return new BasePaginatedList<PromotionModelView>(promotionModelViews, totalCount, pageNumber, pageSize);
        }

        // Thêm mới khuyến mãi
        public async Task<string> AddPromotionAsync(CreatePromotionModelView model, string? userId)
        {
            var existingPromotion = await _unitOfWork.GetRepository<Promotion>().Entities
                .FirstOrDefaultAsync(p => p.Name == model.Name && !p.DeletedTime.HasValue);

            if (existingPromotion != null)
            {
                return "Promotion with the same name already exists";
            }

            Promotion newPromotion = _mapper.Map<Promotion>(model);
            newPromotion.CreatedBy = userId ?? _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
            newPromotion.CreatedTime = DateTimeOffset.UtcNow;

            await _unitOfWork.GetRepository<Promotion>().InsertAsync(newPromotion);
            await _unitOfWork.SaveAsync();

            return "Promotion successfully added";
        }

        // Cập nhật khuyến mãi
        public async Task<string> UpdatePromotionAsync(string id, UpdatePromotionModelView model, string? userId)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return "Please provide a valid Promotion ID.";
            }

            var existingPromotion = await _unitOfWork.GetRepository<Promotion>().Entities
                .FirstOrDefaultAsync(p => p.Id == id && !p.DeletedTime.HasValue);

            if (existingPromotion == null)
            {
                return "The Promotion cannot be found or has been deleted!";
            }

            bool isUpdated = false;

            if (!string.IsNullOrWhiteSpace(model.Name) && model.Name != existingPromotion.Name)
            {
                existingPromotion.Name = model.Name;
                isUpdated = true;
            }

            if (model.DiscountPercentage.HasValue && model.DiscountPercentage != existingPromotion.DiscountPercentage)
            {
                existingPromotion.DiscountPercentage = model.DiscountPercentage.Value;
                isUpdated = true;
            }

            if (model.TotalAmount.HasValue && model.TotalAmount != existingPromotion.TotalAmount)
            {
                existingPromotion.TotalAmount = model.TotalAmount.Value;
                isUpdated = true;
            }

            if (model.MaxAmount.HasValue && model.MaxAmount != existingPromotion.MaxAmount)
            {
                existingPromotion.MaxAmount = model.MaxAmount.Value;
                isUpdated = true;
            }

            if (model.Quantity.HasValue && model.Quantity != existingPromotion.Quantity)
            {
                existingPromotion.Quantity = model.Quantity.Value;
                isUpdated = true;
            }

            if (model.ExpiryDate != existingPromotion.ExpiryDate)
            {
                existingPromotion.ExpiryDate = model.ExpiryDate;
                isUpdated = true;
            }

            if (isUpdated)
            {
                existingPromotion.LastUpdatedBy = userId ?? _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
                existingPromotion.LastUpdatedTime = DateTimeOffset.UtcNow;

                await _unitOfWork.GetRepository<Promotion>().UpdateAsync(existingPromotion);
                await _unitOfWork.SaveAsync();
            }

            return "Promotion successfully updated";
        }

        // Xóa khuyến mãi
        public async Task<string> DeletePromotionAsync(string id, string? userId)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return "Please provide a valid Promotion ID.";
            }

            var existingPromotion = await _unitOfWork.GetRepository<Promotion>().Entities
                .FirstOrDefaultAsync(p => p.Id == id && !p.DeletedTime.HasValue);

            if (existingPromotion == null)
            {
                return "The Promotion cannot be found or has been deleted!";
            }

            existingPromotion.DeletedTime = DateTimeOffset.UtcNow;
            existingPromotion.DeletedBy = userId ?? _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;

            await _unitOfWork.GetRepository<Promotion>().UpdateAsync(existingPromotion);
            await _unitOfWork.SaveAsync();

            return "Promotion successfully deleted";
        }

        // Lấy khuyến mãi theo ID
        public async Task<PromotionModelView?> GetPromotionByIdAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return null;
            }

            var promotionEntity = await _unitOfWork.GetRepository<Promotion>().Entities
                .FirstOrDefaultAsync(p => p.Id == id && !p.DeletedTime.HasValue);

            if (promotionEntity == null)
            {
                return null;
            }

            PromotionModelView promotionModelView = _mapper.Map<PromotionModelView>(promotionEntity);
            return promotionModelView;
        }
    }
}
