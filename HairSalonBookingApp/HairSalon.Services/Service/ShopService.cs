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

        public async Task<BasePaginatedList<ShopModelView>> GetAllShopAsync(int pageNumber, int pageSize)
        {
            IQueryable<Shop> shopQuery = _unitOfWork.GetRepository<Shop>().Entities
                .Where(p => !p.DeletedTime.HasValue)
                .OrderByDescending(s => s.CreatedTime);

            int totalCount = await shopQuery.CountAsync();

            List<Shop> paginatedShops = await shopQuery
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            List<ShopModelView> shopModelViews = _mapper.Map<List<ShopModelView>>(paginatedShops);

            return new BasePaginatedList<ShopModelView>(shopModelViews, totalCount, pageNumber, pageSize);
        }

        public async Task<ShopModelView> AddShopAsync(CreateShopModelView model)
        {
            if (string.IsNullOrWhiteSpace(model.Name))
            {
                throw new Exception("Shop name cannot be empty.");
            }

            Shop newShop = _mapper.Map<Shop>(model);

            newShop.Id = Guid.NewGuid().ToString("N");
            newShop.CreatedBy = "claim account";  
            newShop.CreatedTime = DateTimeOffset.UtcNow;
            newShop.LastUpdatedTime = DateTimeOffset.UtcNow;

            await _unitOfWork.GetRepository<Shop>().InsertAsync(newShop);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<ShopModelView>(newShop);
        }

        public async Task<ShopModelView> UpdateShopAsync(string id, UpdatedShopModelView model)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new Exception("Please provide a valid Shop ID.");
            }

            Shop existingShop = await _unitOfWork.GetRepository<Shop>().Entities
                .FirstOrDefaultAsync(s => s.Id == id && !s.DeletedTime.HasValue)
                ?? throw new Exception("The Shop cannot be found or has been deleted!");

            _mapper.Map(model, existingShop);

            existingShop.LastUpdatedBy = "claim account";  
            existingShop.LastUpdatedTime = DateTimeOffset.UtcNow;

            _unitOfWork.GetRepository<Shop>().Update(existingShop);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<ShopModelView>(existingShop);
        }

        public async Task<string> DeleteShopAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new Exception("Please provide a valid Shop ID.");
            }

            Shop existingShop = await _unitOfWork.GetRepository<Shop>().Entities
                .FirstOrDefaultAsync(s => s.Id == id && !s.DeletedTime.HasValue)
                ?? throw new Exception("The Shop cannot be found or has been deleted!");

            existingShop.DeletedTime = DateTimeOffset.UtcNow;
            existingShop.DeletedBy = "claim account";  

            _unitOfWork.GetRepository<Shop>().Update(existingShop);
            await _unitOfWork.SaveAsync();
            return "Deleted";
        }

        public async Task<ShopModelView> GetShopAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new Exception("Please provide a valid Shop ID.");
            }

            Shop existingShop = await _unitOfWork.GetRepository<Shop>().Entities
                .FirstOrDefaultAsync(s => s.Id == id && !s.DeletedTime.HasValue)
                ?? throw new Exception("The Shop cannot be found or has been deleted!");

            return _mapper.Map<ShopModelView>(existingShop);
        }

    }
}
