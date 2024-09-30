using AutoMapper;
using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Repositories.Interface;
using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.ModelViews.ShopModelViews;
using Microsoft.EntityFrameworkCore;

namespace HairSalon.Services.Service
{
    public class ShopService : IShopService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ShopService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // Get all shops with pagination support
        public async Task<BasePaginatedList<ShopModelView>> GetAllShopAsync(int pageNumber, int pageSize)
        {
            IQueryable<Shop> shopQuery = _unitOfWork.GetRepository<Shop>().Entities
                .Where(p => !p.DeletedTime.HasValue)
                .OrderByDescending(s => s.CreatedTime);

            // Count the total number of matching records
            int totalCount = await shopQuery.CountAsync();

            // Apply pagination
            List<Shop> paginatedShops = await shopQuery
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Map to ShopModelView
            List<ShopModelView> shopModelViews = _mapper.Map<List<ShopModelView>>(paginatedShops);

            return new BasePaginatedList<ShopModelView>(shopModelViews, totalCount, pageNumber, pageSize);
        }

        // Add a new shop
        public async Task<ShopModelView> AddShopAsync(CreateShopModelView model)
        {
            if (string.IsNullOrWhiteSpace(model.Name))
            {
                throw new Exception("Shop name cannot be empty.");
            }

            // Mapping from CreateShopModelView to Shop entity
            Shop newShop = _mapper.Map<Shop>(model);

            // Set additional properties
            newShop.Id = Guid.NewGuid().ToString("N");
            newShop.CreatedBy = "claim account";  // Replace with actual authenticated user
            newShop.CreatedTime = DateTimeOffset.UtcNow;
            newShop.LastUpdatedTime = DateTimeOffset.UtcNow;

            await _unitOfWork.GetRepository<Shop>().InsertAsync(newShop);
            await _unitOfWork.SaveAsync();

            // Map back to ShopModelView and return
            return _mapper.Map<ShopModelView>(newShop);
        }

        // Update an existing shop
        public async Task<ShopModelView> UpdateShopAsync(string id, UpdatedShopModelView model)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new Exception("Please provide a valid Shop ID.");
            }

            // Find the existing shop
            Shop existingShop = await _unitOfWork.GetRepository<Shop>().Entities
                .FirstOrDefaultAsync(s => s.Id == id && !s.DeletedTime.HasValue)
                ?? throw new Exception("The Shop cannot be found or has been deleted!");

            // Mapping from UpdatedShopModel to existing Shop entity
            _mapper.Map(model, existingShop);

            // Set additional properties
            existingShop.LastUpdatedBy = "claim account";  // Replace with actual authenticated user
            existingShop.LastUpdatedTime = DateTimeOffset.UtcNow;

            _unitOfWork.GetRepository<Shop>().Update(existingShop);
            await _unitOfWork.SaveAsync();

            // Map back to ShopModelView and return
            return _mapper.Map<ShopModelView>(existingShop);
        }

        // Soft delete a shop by its ID
        public async Task<string> DeleteShopAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new Exception("Please provide a valid Shop ID.");
            }

            // Find the shop
            Shop existingShop = await _unitOfWork.GetRepository<Shop>().Entities
                .FirstOrDefaultAsync(s => s.Id == id && !s.DeletedTime.HasValue)
                ?? throw new Exception("The Shop cannot be found or has been deleted!");

            // Perform soft delete
            existingShop.DeletedTime = DateTimeOffset.UtcNow;
            existingShop.DeletedBy = "claim account";  // Replace with actual authenticated user

            _unitOfWork.GetRepository<Shop>().Update(existingShop);
            await _unitOfWork.SaveAsync();
            return "Deleted";
        }

        // Get a shop by its ID
        public async Task<ShopModelView> GetShopAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new Exception("Please provide a valid Shop ID.");
            }

            // Find the shop
            Shop existingShop = await _unitOfWork.GetRepository<Shop>().Entities
                .FirstOrDefaultAsync(s => s.Id == id && !s.DeletedTime.HasValue)
                ?? throw new Exception("The Shop cannot be found or has been deleted!");

            // Map to ShopModelView and return
            return _mapper.Map<ShopModelView>(existingShop);
        }

    }
}
