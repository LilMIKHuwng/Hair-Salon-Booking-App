using AutoMapper;
using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Repositories.Interface;
using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.ServiceModelViews;
using ServiceEntity = HairSalon.Contract.Repositories.Entity.Service;
using Microsoft.EntityFrameworkCore;
using HairSalon.Core;
using Microsoft.AspNetCore.Http;

namespace HairSalon.Services.Service
{
    public class ServiceService : IServiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;

        public ServiceService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor contextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _contextAccessor = contextAccessor;

        }

        // Get all services with optional filters for id, ... and support pagination
        public async Task<BasePaginatedList<ServiceModelView>> GetAllServiceAsync(int pageNumber, int pageSize, string id, string name, string type)
        {
            IQueryable<ServiceEntity> serviceQuery = _unitOfWork.GetRepository<ServiceEntity>().Entities
                .Where(p => !p.DeletedTime.HasValue) // Ensure not deleted
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

        // Add a new service
        public async Task<string> AddServiceAsync(CreateServiceModelView model)
        {
            // Validate the input name model
            if (string.IsNullOrWhiteSpace(model.Name))
            {
               return "Service name cannot be empty.";
            }

            // Validate the input type model
            if (string.IsNullOrWhiteSpace(model.Type))
            {
                return "Service type cannot be empty.";
            }

            ServiceEntity newService = _mapper.Map<ServiceEntity>(model);
            
            newService.Id = Guid.NewGuid().ToString("N");
            newService.CreatedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
            newService.CreatedTime = DateTimeOffset.UtcNow;

            await _unitOfWork.GetRepository<ServiceEntity>().InsertAsync(newService);
            await _unitOfWork.SaveAsync();

            return "Service added successfully";
        }

        //Update an existing service
        public async Task<string> UpdateServiceAsync(string id, UpdatedServiceModelView model)
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

            _mapper.Map(model, existingService);

            existingService.LastUpdatedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
            existingService.LastUpdatedTime = DateTimeOffset.UtcNow;

            _unitOfWork.GetRepository<ServiceEntity>().Update(existingService);
            await _unitOfWork.SaveAsync();

            return "Service updated successfully";
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

            _unitOfWork.GetRepository<ServiceEntity>().Update(existingService);
            await _unitOfWork.SaveAsync();
            return "Service deleted successfully";
        }
    }
}
