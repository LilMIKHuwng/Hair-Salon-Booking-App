using AutoMapper;
using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Repositories.Interface;
using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.ModelViews.ShopModelViews;
using Microsoft.EntityFrameworkCore;
using HairSalon.Core.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace HairSalon.Services.Service
{
    public class ShopService : IShopService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;
		private readonly IConfiguration _configuration;

		public ShopService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _contextAccessor = httpContextAccessor;
            _configuration = configuration;
        }

        public async Task<BasePaginatedList<ShopModelView>> GetAllShopAsync
            (int pageNumber, int pageSize, string? searchName, string? searchId)
        {
            // Start a query to get all shops that haven't been deleted
            IQueryable<Shop> shopQuery = _unitOfWork.GetRepository<Shop>().Entities
                .Where(p => !p.DeletedTime.HasValue);

            // If searchName is provided, filter shops by name (case-insensitive search)
            if (!string.IsNullOrWhiteSpace(searchName))
            {
                searchName = searchName.ToLower();
                shopQuery = shopQuery.Where(s => s.Name.ToLower().Contains(searchName));
            }

            // If searchId is provided, filter shops by the provided ID
            if (!string.IsNullOrWhiteSpace(searchId))
            {
                shopQuery = shopQuery.Where(s => s.Id == searchId);
            }

            // Order the results by the created time in descending order
            shopQuery = shopQuery.OrderByDescending(s => s.CreatedTime);

            // Get the total count of shops that match the query (without pagination)
            int totalCount = await shopQuery.CountAsync();

            // Apply pagination by skipping items based on the page number and size, then taking the appropriate page size
            List<Shop> paginatedShops = await shopQuery
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Map the Shop entities to ShopModelView DTOs
            List<ShopModelView> shopModelViews = _mapper.Map<List<ShopModelView>>(paginatedShops);

            // Return a paginated list, including the data, total count, page number, and page size
            return new BasePaginatedList<ShopModelView>(shopModelViews, totalCount, pageNumber, pageSize);
        }


        public async Task<string> AddShopAsync(CreateShopModelView model, string? userId)
        {
            try
            {
                // Map the CreateShopModelView to a Shop entity using AutoMapper
                Shop newShop = _mapper.Map<Shop>(model);

                // Generate a new unique GUID for the Shop ID and set it as a string
                newShop.Id = Guid.NewGuid().ToString("N");

                // Set the CreatedBy field to the current user's ID from the HttpContext
                if (userId != null)
                {
                    newShop.CreatedBy = userId;
                }
                else
                {
                    newShop.CreatedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
                }

                // Set the CreatedTime and LastUpdatedTime to the current UTC time
                newShop.CreatedTime = DateTimeOffset.UtcNow;
                newShop.LastUpdatedTime = DateTimeOffset.UtcNow;


                var imageHelper = new HairSalon.Core.Utils.Firebase.ImageHelper(_configuration);
                string firebaseUrl = await imageHelper.Upload(model.ShopImage);
                newShop.ShopImage = firebaseUrl;

                // Insert the new shop entity into the repository
                await _unitOfWork.GetRepository<Shop>().InsertAsync(newShop);

                // Save the changes to the database
                await _unitOfWork.SaveAsync();

                // Return a success message
                return "Added new shop successfully!";
            }
            catch (BaseException.BadRequestException ex)
            {
                return ex.Message;
            }
            catch (Exception ex)
            {
                return "An error occurred while adding the shop.";
            }
        }

        public async Task<string> UpdateShopAsync(string id, UpdatedShopModelView model, string? userId)
        {
            try
            {
                // Check if the provided Shop ID is valid (non-empty and non-whitespace)
                if (string.IsNullOrWhiteSpace(id))
                {
                    return "Please provide a valid Shop ID.";
                }

                // Retrieve the existing shop based on the provided ID, ensuring it hasn't been deleted
                Shop? existingShop = await _unitOfWork.GetRepository<Shop>().Entities
                    .FirstOrDefaultAsync(s => s.Id == id && !s.DeletedTime.HasValue);

                // If the shop doesn't exist or has been deleted, return an error message
                if (existingShop == null)
                {
                    return "The Shop cannot be found or has been deleted!";
                }

                // Manually map each field to retain existing data if the update fields are null or unchanged
                if (!string.IsNullOrWhiteSpace(model.Name) && model.Name != existingShop.Name)
                {
                    existingShop.Name = model.Name;
                }
                if (!string.IsNullOrWhiteSpace(model.Address) && model.Address != existingShop.Address)
                {
                    existingShop.Address = model.Address;
                }
                if (!string.IsNullOrWhiteSpace(model.ShopEmail) && model.ShopEmail != existingShop.ShopEmail)
                {
                    existingShop.ShopEmail = model.ShopEmail;
                }
                if (!string.IsNullOrWhiteSpace(model.ShopPhone) && model.ShopPhone != existingShop.ShopPhone)
                {
                    existingShop.ShopPhone = model.ShopPhone;
                }
                if (model.OpenTime != null && model.OpenTime != existingShop.OpenTime)
                {
                    existingShop.OpenTime = (TimeSpan)model.OpenTime;
                }

                if (model.CloseTime != null && model.CloseTime != existingShop.CloseTime)
                {
                    existingShop.CloseTime = (TimeSpan)model.CloseTime;
                }

                /*if (model.CloseTime != null)
                {
                    // Check that CloseTime is not earlier than OpenTime
                    if (model.OpenTime != null && model.CloseTime < model.OpenTime)
                    {
                        return "Close time cannot be earlier than open time.";
                    }
                    if (model.CloseTime != existingShop.CloseTime)
                    {
                        existingShop.CloseTime = (TimeSpan)model.CloseTime;
                    }
                }*/

                if (!string.IsNullOrWhiteSpace(model.Title) && model.Title != existingShop.Title)
                {
                    existingShop.Title = model.Title;
                }
                if (model.ShopImage != null)
                {
                    var imageHelper = new HairSalon.Core.Utils.Firebase.ImageHelper(_configuration);
                    string firebaseUrl = await imageHelper.Upload(model.ShopImage);
                    existingShop.ShopImage = firebaseUrl;
                }

                // Update audit fields with the current user and timestamp
                if (userId != null)
                {
                    existingShop.LastUpdatedBy = userId;
                }
                else
                {
                    existingShop.LastUpdatedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
                }
                existingShop.LastUpdatedTime = DateTimeOffset.UtcNow;

                // Update the shop entity in the repository
                await _unitOfWork.GetRepository<Shop>().UpdateAsync(existingShop);

                // Save the changes to the database
                await _unitOfWork.SaveAsync();

                // Return a success message
                return "Updated shop successfully";
            }
            catch (BaseException.BadRequestException ex)
            {
                return ex.Message;
            }
            catch (Exception ex)
            {
                return "An error occurred while updating the shop.";
            }
        }

        public async Task<string> DeleteShopAsync(string id, string? userId)
        {
            try
            {
                // Check if the provided Shop ID is valid (non-empty and non-whitespace)
                if (string.IsNullOrWhiteSpace(id))
                {
                    return "Please provide a valid Shop ID.";
                }

                // Retrieve the existing shop based on the provided ID, ensuring it hasn't been deleted
                Shop existingShop = await _unitOfWork.GetRepository<Shop>().Entities
                    .FirstOrDefaultAsync(s => s.Id == id && !s.DeletedTime.HasValue);

                // If the shop doesn't exist or has been deleted, return an error message
                if (existingShop == null)
                {
                    return "The Shop cannot be found or has been deleted!";
                }

                // Mark the shop as deleted by setting the DeletedTime to the current UTC time
                existingShop.DeletedTime = DateTimeOffset.UtcNow;

                // Record the ID of the user performing the deletion action
                if (userId != null)
                {
                    existingShop.DeletedBy = userId;
                }
                else
                {
                    existingShop.DeletedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
                }

                // Update the shop entity in the repository
                await _unitOfWork.GetRepository<Shop>().UpdateAsync(existingShop);

                // Save the changes to the database
                await _unitOfWork.SaveAsync();

                // Return a success message
                return "Deleted shop successfully";
            }
            catch (BaseException.BadRequestException ex)
            {
                // Return the exception message if a BadRequestException is caught
                return ex.Message;
            }
            catch (Exception ex)
            {
                // Return a generic error message if any other exception occurs
                return "An error occurred while deleting the shop.";
            }
        }

        // Retrieve a shop by its ID
        public async Task<ShopModelView?> GetShopByIdAsync(string id)
        {
            // Check if the provided Role ID is valid (non-empty and non-whitespace)
            if (string.IsNullOrWhiteSpace(id))
            {
                return null; // Or you could throw an exception or return an error message
            }

            // Try to find the role by its ID, ensuring it hasn’t been marked as deleted
            var shopEntity = await _unitOfWork.GetRepository<Shop>().Entities
                .FirstOrDefaultAsync(shop => shop.Id == id && !shop.DeletedTime.HasValue);

            // If the role is not found, return null
            if (shopEntity == null)
            {
                return null;
            }

            // Map the ApplicationRoles entity to a RoleModelView and return it
            ShopModelView shopModelView = _mapper.Map<ShopModelView>(shopEntity);
            return shopModelView;
        }
    }
}