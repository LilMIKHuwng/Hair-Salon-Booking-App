using AutoMapper;
using HairSalon.Contract.Repositories.Interface;
using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.ServiceModelViews;
using ServiceEntity = HairSalon.Contract.Repositories.Entity.Service;
using Microsoft.EntityFrameworkCore;
using HairSalon.Core;
using Microsoft.AspNetCore.Http;
using HairSalon.Core.Base;
using Microsoft.Extensions.Configuration;
using HairSalon.Core.Utils;
using HairSalon.Core.Utils.Firebase;

namespace HairSalon.Services.Service
{
    public class ServiceService : IServiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IConfiguration _configuration;

        public ServiceService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor contextAccessor, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
            _configuration = configuration;
            _configuration = configuration;
        }

        // Get all services with optional filters for id, ... and support pagination
        public async Task<BasePaginatedList<ServiceModelView>> GetAllServiceAsync(int pageNumber, int pageSize, string? id, string? name, string? type)
        {
            IQueryable<ServiceEntity> serviceQuery = _unitOfWork.GetRepository<ServiceEntity>().Entities
                .Where(p => !p.DeletedTime.HasValue)
                .OrderByDescending(s => s.CreatedTime);

            // Apply filter for 'id' if provided
            if (!string.IsNullOrWhiteSpace(id))
            {
                serviceQuery = serviceQuery.Where(s => s.Id == id);
            }

            // Apply filter for 'name' if provided
            if (!string.IsNullOrWhiteSpace(name))
            {
                serviceQuery = serviceQuery.Where(s => s.Name.Contains(name));
            }

            // Apply filter for 'type' if provided
            if (!string.IsNullOrWhiteSpace(type))
            {
                serviceQuery = serviceQuery.Where(s => s.Type == type);
            }

            int totalCount = await serviceQuery.CountAsync();

            List<ServiceEntity> paginatedServices = await serviceQuery
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            List<ServiceModelView> serviceModelViews = _mapper.Map<List<ServiceModelView>>(paginatedServices);

            return new BasePaginatedList<ServiceModelView>(serviceModelViews, totalCount, pageNumber, pageSize);
        }

		//Get all without pagination
		public async Task<List<ServiceModelView>> GetAllServiceAsync()
        {
			List<ServiceEntity> serviceList = _unitOfWork.GetRepository<ServiceEntity>().Entities
				.Where(p => !p.DeletedTime.HasValue)
				.OrderByDescending(s => s.CreatedTime)
                .ToList();

			List<ServiceModelView> serviceModelViews = _mapper.Map<List<ServiceModelView>>(serviceList);

			return serviceModelViews;
		}

		// Add a new service
		public async Task<string> AddServiceAsync(CreateServiceModelView model)
        {
            try
            {
                ServiceEntity newService = _mapper.Map<ServiceEntity>(model);

                var imageHelper = new HairSalon.Core.Utils.Firebase.ImageHelper(_configuration);
                string firebaseUrl = await imageHelper.Upload(model.ServiceImage);
                newService.ServiceImage = firebaseUrl;

                newService.Id = Guid.NewGuid().ToString("N");
                newService.CreatedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
                newService.CreatedTime = DateTimeOffset.UtcNow;

                await _unitOfWork.GetRepository<ServiceEntity>().InsertAsync(newService);
                await _unitOfWork.SaveAsync();

                return "Service added successfully";
            }
            catch (BaseException.BadRequestException ex)
            {
                return ex.Message;
            }
            catch (Exception ex)
            {
                return "An error occurred while adding the service.";
            }
        }

        //Update an existing service
        public async Task<string> UpdateServiceAsync(string id, UpdatedServiceModelView model)
        {
            try
            {
                // Check if the provided id is null, empty, or whitespace
                if (string.IsNullOrWhiteSpace(id))
                {
                    return "Please provide a valid Service ID.";
                }

                // Check for existing service
                ServiceEntity existingService = await _unitOfWork.GetRepository<ServiceEntity>().Entities
                    .FirstOrDefaultAsync(s => s.Id == id && !s.DeletedTime.HasValue);

                if (existingService == null)
                {
                    return "The Service cannot be found or has been deleted!";
                }

                // Update the service fields only if they are not null
                if (!string.IsNullOrWhiteSpace(model.Name))
                {
                    existingService.Name = model.Name;
                }

                if (!string.IsNullOrWhiteSpace(model.Type))
                {
                    existingService.Type = model.Type;
                }

                if (model.Price.HasValue)
                {
                    existingService.Price = model.Price.Value;
                }

                if (!string.IsNullOrWhiteSpace(model.Description))
                {
                    existingService.Description = model.Description;
                }

                if (model.TimeService.HasValue)
                {
                    existingService.TimeService = model.TimeService.Value;
                }


                if (!string.IsNullOrWhiteSpace(model.ShopId))
                {
                    existingService.ShopId = model.ShopId;
                }

                if (model.ServiceImage != null)
                {
                    var imageHelper = new HairSalon.Core.Utils.Firebase.ImageHelper(_configuration);
                    string firebaseUrl = await imageHelper.Upload(model.ServiceImage);
                    existingService.ServiceImage = firebaseUrl;
                }

                existingService.LastUpdatedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
                existingService.LastUpdatedTime = DateTimeOffset.UtcNow;

                await _unitOfWork.GetRepository<ServiceEntity>().UpdateAsync(existingService);
                await _unitOfWork.SaveAsync();

                return "Service updated successfully";
            }
            catch (BaseException.BadRequestException ex)
            {
                return ex.Message;
            }
            catch (Exception ex)
            {
                return "An error occurred while updating the service.";
            }
        }

        // Soft delete a service
        public async Task<string> DeleteServiceAsync(string id)
        {
            // Check if the provided id is null, empty, or whitespace
            if (string.IsNullOrWhiteSpace(id))
            {
                return "Please provide a valid Service ID.";
            }

            // Check for existing service
            ServiceEntity existingService = await _unitOfWork.GetRepository<ServiceEntity>().Entities
                .FirstOrDefaultAsync(s => s.Id == id && !s.DeletedTime.HasValue);

            if (existingService == null)
            {
                return "The Service cannot be found or has been deleted!";
            }

            existingService.DeletedTime = DateTimeOffset.Now;
            existingService.DeletedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;

            await _unitOfWork.GetRepository<ServiceEntity>().UpdateAsync(existingService);
            await _unitOfWork.SaveAsync();
            return "Service deleted successfully";
        }

        // Get a service by multiple IDs
        public async Task<IEnumerable<ServiceModelView>> GetByIdsAsync(string[] ids)
        {
            if (ids == null || ids.Length == 0)
            {
                return Enumerable.Empty<ServiceModelView>();
            }

            var services = await _unitOfWork.GetRepository<ServiceEntity>().Entities
                .Where(s => ids.Contains(s.Id) && !s.DeletedTime.HasValue)
                .ToListAsync();

            return _mapper.Map<List<ServiceModelView>>(services);
        }

		public async Task<List<ServiceModelView>> GetAllServicesAsync()
		{
			// Try to find all services not deleted
			var list = await _unitOfWork.GetRepository<HairSalon.Contract.Repositories.Entity.Service>().Entities
				.Where(a => !a.DeletedTime.HasValue)
				.ToListAsync();

			// If the services is not found, return null
			if (list == null)
			{
				return null;
			}

			// Map the service entity to a ServiceModelView and return it
			var serviceModelViews = _mapper.Map<List<ServiceModelView>>(list);

			return serviceModelViews;
		}
	}
}
