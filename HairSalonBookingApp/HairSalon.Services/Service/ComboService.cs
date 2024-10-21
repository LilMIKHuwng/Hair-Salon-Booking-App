using AutoMapper;
using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Repositories.Interface;
using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.ModelViews.ComboModelViews;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace HairSalon.Services.Service
{
    public class ComboService : IComboService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;

        public ComboService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _contextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        // Create a new Combo
        public async Task<string> CreateComboAsync(CreateComboModelView model)
        {

            // Check if the combo name already exists
            var existingCombo = await _unitOfWork.GetRepository<Combo>().Entities
                .FirstOrDefaultAsync(c => c.Name == model.Name && !c.DeletedTime.HasValue);

            if (existingCombo != null)
            {
                return ($"Combo with the name '{model.Name}' already exists.");
            }

            // Check for duplicates in ServiceIds
            var serviceIdList = model.ServiceIds.ToList(); // Convert to List to enable operations
            var uniqueServiceIds = new HashSet<string>(serviceIdList);

            if (uniqueServiceIds.Count < serviceIdList.Count)
            {
                return ("Duplicate Service IDs found.");
            }

            // Initialize a new Combo
            Combo newCombo = _mapper.Map<Combo>(model);
            newCombo.Id = Guid.NewGuid().ToString("N");
            newCombo.CreatedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
            newCombo.CreatedTime = DateTimeOffset.UtcNow;
            newCombo.LastUpdatedTime = DateTimeOffset.UtcNow;

            // Initialize total values for the Combo
            decimal totalPrice = 0;
            int totalTime = 0;

            // Loop through each selected service ID
            foreach (var serviceId in model.ServiceIds)
            {
                // Retrieve the service from the database
                var service = await _unitOfWork.GetRepository<HairSalon.Contract.Repositories.Entity.Service>().GetByIdAsync(serviceId);

                if (service == null)
                {
                    return ($"Service with ID {serviceId} not found.");
                }

                // Sum the time and price of each service
                totalTime += service.TimeService;
                totalPrice += service.Price;

                // Add a record in ComboServices (for the many-to-many relationship between Combo and Service)
                ComboServices comboService = new ComboServices
                {
                    Id = Guid.NewGuid().ToString("N"),
                    ServiceId = serviceId,
                    ComboId = newCombo.Id,
                    CreatedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value,
                    CreatedTime = DateTimeOffset.UtcNow,
                    LastUpdatedTime = DateTimeOffset.UtcNow
                };

                // Insert the ComboServices record
                await _unitOfWork.GetRepository<ComboServices>().InsertAsync(comboService);
            }

            // Apply a 10% discount to the total price
            decimal discountedPrice = totalPrice * 0.9m;

            // Set the total price and time of the combo
            newCombo.TotalPrice = discountedPrice;
            newCombo.TimeCombo = totalTime;

            // Save the combo to the database
            await _unitOfWork.GetRepository<Combo>().InsertAsync(newCombo);
            await _unitOfWork.SaveAsync();

            return "Combo successfully created.";
        }


        //update combo
        public async Task<string> UpdateComboAsync(string id, UpdateComboModelView model)
        {
            // Retrieve the combo by its ID
            var existingCombo = await _unitOfWork.GetRepository<Combo>().GetByIdAsync(id);
            if (existingCombo == null)
            {
                return("Combo not found.");
            }

            if (!string.IsNullOrWhiteSpace(model.Name))
            {
                existingCombo.Name = model.Name;
            }

            // Update combo details (Name, etc.)
            existingCombo.LastUpdatedTime = DateTimeOffset.UtcNow;
            existingCombo.LastUpdatedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;

			// Handle update ServiceIds if any
			if (model.ServiceIds != null && model.ServiceIds.Length > 0)
			{
				var updateResult = await UpdateServiceAppointmentsAsync(existingCombo.Id, model.ServiceIds, existingCombo.TimeCombo, existingCombo.TotalPrice / 90 * 100);
				// Update the combo details
				existingCombo.TotalPrice = updateResult.TotalPrice * 0.9m;  // Discounted price
				existingCombo.TimeCombo = updateResult.TimeCombo;
			}

            // Save changes to the database
            await _unitOfWork.GetRepository<Combo>().UpdateAsync(existingCombo);
            await _unitOfWork.SaveAsync();

            return "Combo successfully updated with services.";
        }

        //Calculate TimeCombo and TotalPrice when Update
		private async Task<(int TimeCombo, decimal TotalPrice)> UpdateServiceAppointmentsAsync(string comboId, string[] serviceIds, int currentTimeCombo, decimal currentTotalPrice)
		{
			var existingComboServices = await _unitOfWork.GetRepository<ComboServices>().Entities
				.Where(sa => sa.ComboId == comboId && !sa.DeletedTime.HasValue).ToListAsync();

			// Delete services that are no longer in the new list
			var servicesToRemove = existingComboServices.Where(sa => !serviceIds.Contains(sa.ServiceId)).ToList();
			foreach (var comboService in servicesToRemove)
			{
				comboService.DeletedTime = DateTimeOffset.UtcNow;
				comboService.DeletedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
				var service = (await _unitOfWork.GetRepository<HairSalon.Contract.Repositories.Entity.Service>().GetByIdAsync(comboService.ServiceId));
				currentTimeCombo -= service.TimeService;
				currentTotalPrice -= service.Price;
			}

			// Add new serviceAppointment
			var currentServiceIds = existingComboServices.Select(sa => sa.ServiceId).ToList();
			var servicesToAdd = serviceIds.Where(s => !currentServiceIds.Contains(s)).ToList();
			foreach (var serviceId in servicesToAdd)
			{
				var comboService = new ComboServices
				{
					ServiceId = serviceId,
					ComboId = comboId,
					LastUpdatedTime = DateTimeOffset.UtcNow,
					LastUpdatedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value
				};
				await _unitOfWork.GetRepository<ComboServices>().InsertAsync(comboService);
				var service = (await _unitOfWork.GetRepository<HairSalon.Contract.Repositories.Entity.Service>().GetByIdAsync(serviceId));
				currentTimeCombo += service.TimeService;
				currentTotalPrice += service.Price;
			}

			return (currentTimeCombo, currentTotalPrice);
		}

		// Delete a Combo
		public async Task<string> DeleteComboAsync(string id)
        {

            if (string.IsNullOrWhiteSpace(id))
            {
                return "Invalid combo ID. Please provide a valid ID.";
            }

            var existingCombo = await _unitOfWork.GetRepository<Combo>().Entities
                .FirstOrDefaultAsync(s => s.Id == id && !s.DeletedTime.HasValue);

            if (existingCombo == null)
            {
                return "Combo not found or has already been deleted.";
            }
            existingCombo.DeletedTime = DateTimeOffset.UtcNow;
            existingCombo.DeletedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;

            // Lấy tất cả các dịch vụ trong combo và cập nhật thông tin xóa
            var comboServices = await _unitOfWork.GetRepository<ComboServices>()
                .Entities.Where(cs => cs.ComboId == id && !cs.DeletedTime.HasValue)
                .ToListAsync();

            foreach (var comboService in comboServices)
            {
                comboService.DeletedTime = DateTimeOffset.UtcNow;
                comboService.DeletedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;

                // Cập nhật thực thể thay vì xóa hoàn toàn
                await _unitOfWork.GetRepository<ComboServices>().UpdateAsync(comboService);
            }

            await _unitOfWork.GetRepository<Combo>().UpdateAsync(existingCombo);
            await _unitOfWork.SaveAsync();
            return "Deleted combo successfully!";
        }

        // Get all Combos with pagination
        public async Task<BasePaginatedList<ComboModelView>> GetAllCombosAsync(int pageNumber, int pageSize, string? id = null, string? name = null)
        {
            IQueryable<Combo> roleQuery = _unitOfWork.GetRepository<Combo>().Entities
                .Where(p => !p.DeletedTime.HasValue);

            // Apply filtering by userId if provided
            if (!string.IsNullOrEmpty(id))
            {
                roleQuery = roleQuery.Where(u => u.Id.ToString() == id);
            }

            if (!string.IsNullOrWhiteSpace(name))
            {
                roleQuery = roleQuery.Where(s => s.Name.Contains(name));
            }

            // Order by CreatedTime descending
            roleQuery = roleQuery.OrderByDescending(s => s.CreatedTime);

            // Get total count
            int totalCount = await roleQuery.CountAsync();

            // Get paginated results
            List<Combo> paginatedUsers = await roleQuery
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Map to ComboModelView
            List<ComboModelView> comboModelView = _mapper.Map<List<ComboModelView>>(paginatedUsers);

            // Return paginated list
            return new BasePaginatedList<ComboModelView>(comboModelView, totalCount, pageNumber, pageSize);
        }
    }
}
