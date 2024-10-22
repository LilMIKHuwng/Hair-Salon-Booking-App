using AutoMapper;
using HairSalon.Contract.Repositories.Interface;
using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.ServiceModelViews;
using ServiceEntity = HairSalon.Contract.Repositories.Entity.Service;
using Microsoft.EntityFrameworkCore;
using HairSalon.Core;
using Microsoft.AspNetCore.Http;
using HairSalon.Contract.Repositories.Entity;
using HairSalon.Core.Utils;

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

        // Add a new service
        public async Task<string> AddServiceAsync(CreateServiceModelView model)
        {
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

			if (!string.IsNullOrWhiteSpace(model.ShopId))
			{
				existingService.ShopId = model.ShopId;
			}

			existingService.LastUpdatedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
            existingService.LastUpdatedTime = DateTimeOffset.UtcNow;

            await _unitOfWork.GetRepository<ServiceEntity>().UpdateAsync(existingService);
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

            await _unitOfWork.GetRepository<ServiceEntity>().UpdateAsync(existingService);
            await _unitOfWork.SaveAsync();
            return "Service deleted successfully";
        }

        // Get number of each service per month
        public async Task<BasePaginatedList<StatisticalServiceModelView>> MonthlyServiceStatistics(int pageNumber, int pageSize, int? year, int? month)
        {
            if (month.HasValue && !year.HasValue)
            {
                return new BasePaginatedList<StatisticalServiceModelView>(new List<StatisticalServiceModelView>(), 0, pageNumber, pageSize);
            }

            // Query the ServiceAppointment table to retrieve appointment and service information
            var serviceUsageQuery = _unitOfWork.GetRepository<ServiceAppointment>().Entities
                .Include(sa => sa.Service)
                .Include(sa => sa.Appointment)
                .Where(sa => sa.Appointment.AppointmentDate.Year == year &&
                             (!month.HasValue || sa.Appointment.AppointmentDate.Month == month) && 
                             !sa.DeletedTime.HasValue) // Filter by year and month
                .GroupBy(sa => sa.Service.Name) // Group by Service Name 
                .Select(group => new StatisticalServiceModelView
                {
                    ServiceName = group.Key,
                    UsageCount = group.Count()
                })
                .OrderByDescending(x => x.UsageCount);

            // Calculate the total number of services used
            int totalCount = await serviceUsageQuery.CountAsync();

            // Retrieve paginated data
            var paginatedServiceUsage = await serviceUsageQuery
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Return the paginated list
            return new BasePaginatedList<StatisticalServiceModelView>(paginatedServiceUsage, totalCount, pageNumber, pageSize);
        }
    }
}
