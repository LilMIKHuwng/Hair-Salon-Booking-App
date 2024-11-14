using AutoMapper;
using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Repositories.Interface;
using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.Core.Base;
using HairSalon.ModelViews.ComboModelViews;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HairSalon.Services.Service
{
	public class ComboService : IComboService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IHttpContextAccessor _contextAccessor;
		private readonly IMapper _mapper;
		private readonly IConfiguration _configuration;

		public ComboService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, IMapper mapper, IConfiguration configuration)
		{
			_unitOfWork = unitOfWork;
			_contextAccessor = httpContextAccessor;
			_mapper = mapper;
			_configuration = configuration;
		}

		// Create a new Combo
		public async Task<string> CreateComboAsync(CreateComboModelView model, string? userId)
		{
			try
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
				// Assign additional properties: CreatedBy and LastUpdatedBy from the current user's information
				if (userId != null)
				{
					newCombo.CreatedBy = userId;
					newCombo.LastUpdatedBy = userId;
				}
				else
				{
					newCombo.LastUpdatedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
					newCombo.CreatedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
				}
				newCombo.CreatedTime = DateTimeOffset.UtcNow;
				newCombo.LastUpdatedTime = DateTimeOffset.UtcNow;

				var imageHelper = new HairSalon.Core.Utils.Firebase.ImageHelper(_configuration);
				string firebaseUrl = await imageHelper.Upload(model.ComboImage);
				newCombo.ComboImage = firebaseUrl;

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
			catch (BaseException.BadRequestException ex)
			{
				return ex.Message;
			}
			catch (Exception ex)
			{
				return "An error occurred while adding the combo. " + ex.Message;
			}

		}

		//update combo
		public async Task<string> UpdateComboAsync(string id, UpdateComboModelView model, string? userId)
		{
			try
			{
				// Lấy thông tin combo từ ID
				var existingCombo = await _unitOfWork.GetRepository<Combo>().GetByIdAsync(id);
				if (existingCombo == null)
				{
					return "Combo not found.";
				}

				// Cập nhật tên combo nếu có
				if (!string.IsNullOrWhiteSpace(model.Name))
				{
					existingCombo.Name = model.Name;
				}

				// Cập nhật thời gian và người dùng cuối cùng đã cập nhật
				existingCombo.LastUpdatedTime = DateTimeOffset.UtcNow;
				if (userId != null)
				{
					existingCombo.LastUpdatedBy = userId;
				}
				else
				{
					existingCombo.LastUpdatedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
				}

				// Xử lý cập nhật danh sách dịch vụ
				if (model.ServiceIds != null && model.ServiceIds.Length > 0)
				{
					var updateResult = await UpdateServiceAppointmentsAsync(
						existingCombo.Id,
						model.ServiceIds,
						existingCombo.TimeCombo,
						existingCombo.TotalPrice / 90 * 100,
						userId
					);

					// Tính toán và áp dụng giá chiết khấu
					const decimal DiscountRate = 0.9m;
					existingCombo.TotalPrice = updateResult.TotalPrice * DiscountRate;
					existingCombo.TimeCombo = updateResult.TimeCombo;
				}

				// Tải lên ảnh combo nếu có
				if (model.ComboImage != null)
				{
					var imageHelper = new HairSalon.Core.Utils.Firebase.ImageHelper(_configuration);
					string firebaseUrl = await imageHelper.Upload(model.ComboImage);
					existingCombo.ComboImage = firebaseUrl;
				}

				// Lưu thay đổi vào cơ sở dữ liệu
				await _unitOfWork.GetRepository<Combo>().UpdateAsync(existingCombo);
				await _unitOfWork.SaveAsync();

				return "Combo successfully updated with services.";
			}
			catch (BaseException.BadRequestException ex)
			{
				// Lỗi yêu cầu sai từ người dùng (BadRequest)
				return ex.Message;
			}
			catch (Exception ex)
			{
				// Lỗi không xác định
				return "An error occurred while updating the combo.";
			}
		}

		//Calculate TimeCombo and TotalPrice when Update
		private async Task<(int TimeCombo, decimal TotalPrice)> UpdateServiceAppointmentsAsync(string comboId, string[] serviceIds, int currentTimeCombo, decimal currentTotalPrice, string? userId)
		{
			var existingComboServices = await _unitOfWork.GetRepository<ComboServices>().Entities
				.Where(sa => sa.ComboId == comboId && !sa.DeletedTime.HasValue).ToListAsync();

			// Delete services that are no longer in the new list
			var servicesToRemove = existingComboServices.Where(sa => !serviceIds.Contains(sa.ServiceId)).ToList();
			foreach (var comboService in servicesToRemove)
			{
				comboService.DeletedTime = DateTimeOffset.UtcNow;
				if (userId != null)
				{
					comboService.DeletedBy = userId;
					comboService.LastUpdatedBy = userId;
				}
				else
				{
					comboService.DeletedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
					comboService.LastUpdatedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
				}
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
				};

				//Assign userId to lastupdatedby
				if (userId != null)
				{
					comboService.LastUpdatedBy = userId;
				}
				else
				{
					comboService.LastUpdatedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
				}

				await _unitOfWork.GetRepository<ComboServices>().InsertAsync(comboService);
				var service = (await _unitOfWork.GetRepository<HairSalon.Contract.Repositories.Entity.Service>().GetByIdAsync(serviceId));
				currentTimeCombo += service.TimeService;
				currentTotalPrice += service.Price;
			}

			return (currentTimeCombo, currentTotalPrice);
		}

		// Delete a Combo
		public async Task<string> DeleteComboAsync(string id, string? userId)
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
			existingCombo.LastUpdatedTime = DateTimeOffset.UtcNow;
			// Record the ID of the user performing the deletion action
			if (userId != null)
			{
				existingCombo.DeletedBy = userId;
				existingCombo.LastUpdatedBy = userId;
			}
			else
			{
				existingCombo.DeletedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
				existingCombo.LastUpdatedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
			}

			// Get all service in combo
			var comboServices = await _unitOfWork.GetRepository<ComboServices>()
				.Entities.Where(cs => cs.ComboId == id && !cs.DeletedTime.HasValue)
				.ToListAsync();

			foreach (var comboService in comboServices)
			{
				comboService.DeletedTime = DateTimeOffset.UtcNow;
				comboService.LastUpdatedTime = DateTimeOffset.UtcNow;
				if (userId != null)
				{
					comboService.DeletedBy = userId;
					comboService.LastUpdatedBy = userId;
				}
				else
				{
					comboService.DeletedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
					comboService.LastUpdatedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
				}
				// Update
				await _unitOfWork.GetRepository<ComboServices>().UpdateAsync(comboService);
			}

			await _unitOfWork.GetRepository<Combo>().UpdateAsync(existingCombo);
			await _unitOfWork.SaveAsync();
			return "Deleted combo successfully!";
		}

		// Get all Combos with pagination
		public async Task<BasePaginatedList<ComboModelView>> GetAllCombosAsync(int pageNumber, int pageSize, string? id = null, string? name = null)
		{
			// Start with the base query for combos that are not deleted
			IQueryable<Combo> comboQuery = _unitOfWork.GetRepository<Combo>().Entities
				.Where(p => !p.DeletedTime.HasValue);

			// Filter by Combo ID if provided
			if (!string.IsNullOrEmpty(id))
			{
				comboQuery = comboQuery.Where(u => u.Id.ToString() == id);
			}

			// Filter by Combo name if provided
			if (!string.IsNullOrWhiteSpace(name))
			{
				comboQuery = comboQuery.Where(s => s.Name.Contains(name));
			}

			// Order by CreatedTime descending
			comboQuery = comboQuery.OrderByDescending(s => s.CreatedTime);

			// Get total count
			int totalCount = await comboQuery.CountAsync();

			// Get paginated Combo results
			List<Combo> paginatedCombos = await comboQuery
				.Skip((pageNumber - 1) * pageSize)
				.Take(pageSize)
				.ToListAsync();

			// Retrieve ComboServices for each Combo
			var comboIds = paginatedCombos.Select(c => c.Id).ToList();
			var comboServices = await _unitOfWork.GetRepository<ComboServices>().Entities
				.Where(cs => comboIds.Contains(cs.ComboId) && !cs.DeletedTime.HasValue)
				.ToListAsync();

			// Map Combo and ComboServices to ComboModelView
			var comboModelViews = paginatedCombos.Select(combo =>
			{
				var model = _mapper.Map<ComboModelView>(combo);
				model.ServiceIds = comboServices
									.Where(cs => cs.ComboId == combo.Id)
									.Select(cs => cs.ServiceId.ToString())
									.ToArray();
				return model;
			}).ToList();

			// Return paginated list
			return new BasePaginatedList<ComboModelView>(comboModelViews, totalCount, pageNumber, pageSize);
		}

		public async Task<ComboModelView?> GetComboByIdAsync(string id)
		{
			// Get the combo entity along with its services
			var comboEntity = await _unitOfWork.GetRepository<Combo>().Entities
									.Include(c => c.ComboServices) // Include the related ComboServices
									.FirstOrDefaultAsync(combo => combo.Id.Equals(id) && !combo.DeletedTime.HasValue);

			// If the combo is not found, return null
			if (comboEntity == null)
			{
				return null;
			}

			// Map the Combo entity to ComboModelView
			ComboModelView comboModelView = _mapper.Map<ComboModelView>(comboEntity);

			// Retrieve ServiceIds from the related ComboServices
			comboModelView.ServiceIds = comboEntity.ComboServices
									 .Where(cs => !cs.DeletedTime.HasValue)
									 .Select(cs => cs.ServiceId.ToString())
									 .ToArray();

			return comboModelView;
		}

		public async Task<List<ComboModelView>> GetAllComboAsync()
		{
			// Try to find all combos not deleted
			var list = await _unitOfWork.GetRepository<Combo>().Entities
				.Where(a => !a.DeletedTime.HasValue)
				.ToListAsync();

			// If list combos is not found, return null
			if (list == null)
			{
				return null;
			}

			// Map the service entity to a ServiceModelView and return it
			var comboModelViews = _mapper.Map<List<ComboModelView>>(list);

			return comboModelViews;
		}
	}
}
