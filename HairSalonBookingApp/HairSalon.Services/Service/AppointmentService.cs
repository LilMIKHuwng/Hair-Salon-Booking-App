using AutoMapper;
using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Repositories.Interface;
using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.ModelViews.AppointmentModelViews;
using HairSalon.Repositories.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace HairSalon.Services.Service
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;

        public AppointmentService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor contextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
        }

        //check stylist is busy or not
        private async Task<bool> IsStylistBusy(Guid stylistId, DateTime appointmentDate, int newTotalTime, string? appointmentId = null)
        {
            return await _unitOfWork.GetRepository<Appointment>().Entities
                .AnyAsync(p => p.StylistId == stylistId
                    && (appointmentId == null || p.Id != appointmentId)
                    && !p.StatusForAppointment.Equals("Cancelled")
                    && !p.DeletedTime.HasValue
                    && !(appointmentDate.AddMinutes(newTotalTime) <= p.AppointmentDate
                    || appointmentDate >= p.AppointmentDate.AddMinutes(p.TotalTime)));
        }

        //check duplicate appointment
        private async Task<bool> IsDuplicateAppointment(Guid userId, DateTime appointmentDate, int newTotalTime, string? appointmentId = null)
        {
            return await _unitOfWork.GetRepository<Appointment>().Entities
                .AnyAsync(p => p.UserId == userId
                    && (appointmentId == null || p.Id != appointmentId)
                    && !p.StatusForAppointment.Equals("Cancelled")
                    && !p.DeletedTime.HasValue
                    && !(appointmentDate.AddMinutes(newTotalTime) <= p.AppointmentDate
                    || appointmentDate >= p.AppointmentDate.AddMinutes(p.TotalTime)));
        }

        // calculate total time, price of service and combo
        private async Task<(int totalTime, decimal totalPrice)> calculateTotalTimePrice(string[]? serviceIds, string[]? comboIds)
        {
            int totalTime = 0;
            decimal totalPrice = 0;

            if (!serviceIds.IsNullOrEmpty())
            {
                var services = await _unitOfWork.GetRepository<HairSalon.Contract.Repositories.Entity.Service>().Entities
                    .Where(s => serviceIds.Contains(s.Id))
                    .ToListAsync();

                totalTime += services.Sum(s => s.TimeService);
                totalPrice += services.Sum(s => s.Price);
            }

            if (!comboIds.IsNullOrEmpty())
            {
                var combos = await _unitOfWork.GetRepository<Combo>().Entities
                    .Where(c => comboIds.Contains(c.Id))
                    .ToListAsync();

                totalTime += combos.Sum(c => c.TimeCombo);
                totalPrice += combos.Sum(c => c.TotalPrice);
            }
            return (totalTime, totalPrice);
        }

        // Add a new appointment
        public async Task<string> AddAppointmentAsync(CreateAppointmentModelView model, string? userId)
        {
            if (userId == null)
            {
                userId = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
            }

            // Get the user by userId
            var user = await _unitOfWork.GetRepository<ApplicationUsers>()
                .GetByIdAsync(Guid.Parse(userId));
            if (user == null)
            {
                return "User is not found.";
            }

            if (model.ComboIds.IsNullOrEmpty() && model.ServiceIds.IsNullOrEmpty())
            {
                return "You need choose at least one service or combo";
            }

            // Check for duplicate services
            if (model.ServiceIds != null && model.ServiceIds.Distinct().Count() != model.ServiceIds.Length)
            {
                return "Duplicate services found. Please remove the duplicate services.";
            }

            // Check for duplicate combos
            if (model.ComboIds != null && model.ComboIds.Distinct().Count() != model.ComboIds.Length)
            {
                return "Duplicate combos found. Please remove the duplicate combos.";
            }

            // Check if user has enough points
            if (model.PointsEarned > user.UserInfo.Point)
            {
                return "Insufficient points. The user does not have enough points for this appointment.";
            }

            var (totalTime, totalPrice) = await calculateTotalTimePrice(model.ServiceIds, model.ComboIds);

            // Validate appointment date
            if (model.AppointmentDate < DateTime.Now || model.AppointmentDate > DateTime.Now.AddMonths(1))
            {
                return "Invalid appointment date. The date must be within one month from today.";
            }

            bool isConflictAppointment = await IsDuplicateAppointment(user.Id, model.AppointmentDate, totalTime);

            if (isConflictAppointment)
            {
                return "You have other appointment at that time";
            }

            // Check valid stylist
            if (model.StylistId.IsNullOrEmpty())
            {
                // Retrieve a list of available stylists who are active and not deleted
                var role = await _unitOfWork.GetRepository<ApplicationRoles>()
                    .Entities
                    .FirstOrDefaultAsync(r => r.Name == "Stylist");
                var availableStylists = await _unitOfWork.GetRepository<ApplicationUserRoles>()
                    .Entities
                    .Where(ur => ur.RoleId.Equals(role.Id)
                        && !ur.DeletedTime.HasValue
                        && !ur.User.DeletedTime.HasValue)
                    .Select(ur => ur.User)
                    .ToListAsync();

                // Dictionary to store stylist and their appointment count
                Dictionary<Guid, int> stylistAppointmentsCount = new Dictionary<Guid, int>();

                // Check each stylist to see if they are available at the requested time and count their appointments
                foreach (var stylists in availableStylists)
                {
                    bool isStylistAvailable = !await IsStylistBusy(stylists.Id, model.AppointmentDate, totalTime);

                    // If stylist is available, count their total appointments
                    if (isStylistAvailable)
                    {
                        int appointmentCount = await _unitOfWork.GetRepository<Appointment>().Entities
                            .CountAsync(p => p.StylistId == stylists.Id && !p.StatusForAppointment.Equals("Cancelled") && !p.DeletedTime.HasValue);

                        stylistAppointmentsCount.Add(stylists.Id, appointmentCount); // Add stylist and their appointment count
                    }
                }

                // If no stylist is available, return error message
                if (!stylistAppointmentsCount.Any())
                {
                    return "No available stylist found at the requested time.";
                }

                // Select the stylist with the least number of appointments
                var stylistWithLeastAppointments = stylistAppointmentsCount.OrderBy(s => s.Value).FirstOrDefault();

                // Assign the stylist ID with the least appointments to the model
                model.StylistId = stylistWithLeastAppointments.Key.ToString();
            }
            else
            {
                // check stylist don't have any appointment
                bool isStylistBusy = await IsStylistBusy(Guid.Parse(model.StylistId), model.AppointmentDate, totalTime);

                if (isStylistBusy)
                {
                    return "Stylist has other appointment at that time";
                }
            }

            // Map data model to entity
            Appointment newAppointment = _mapper.Map<Appointment>(model);
            newAppointment.Id = Guid.NewGuid().ToString("N");
            newAppointment.UserId = user.Id;
            newAppointment.StatusForAppointment = "Scheduled";
            newAppointment.TotalTime = totalTime;
            newAppointment.TotalAmount = totalPrice;
            newAppointment.CreatedBy = userId;
            newAppointment.CreatedTime = DateTimeOffset.UtcNow;
            newAppointment.LastUpdatedTime = DateTimeOffset.UtcNow;

            // create service appointment
            if (!model.ServiceIds.IsNullOrEmpty())
            {
                foreach (var serviceId in model.ServiceIds)
                {
                    ServiceAppointment serviceAppointment = new ServiceAppointment
                    {
                        Id = Guid.NewGuid().ToString("N"),
                        AppointmentId = newAppointment.Id,
                        ServiceId = serviceId,
                        CreatedBy = userId,
                        CreatedTime = DateTimeOffset.UtcNow,
                        LastUpdatedTime = DateTimeOffset.UtcNow
                    };

                    // Add each ServiceAppointment to the repository
                    await _unitOfWork.GetRepository<ServiceAppointment>().InsertAsync(serviceAppointment);
                }
            }

            // create ComboService appointment
            if (!model.ComboIds.IsNullOrEmpty())
            {
                foreach (var comboId in model.ComboIds)
                {
                    ComboAppointment comboAppointment = new ComboAppointment
                    {
                        Id = Guid.NewGuid().ToString("N"),
                        AppointmentId = newAppointment.Id,
                        ComboId = comboId,
                        CreatedBy = userId,
                        CreatedTime = DateTimeOffset.UtcNow,
                        LastUpdatedTime = DateTimeOffset.UtcNow
                    };

                    // Add each ComboAppointment to the repository
                    await _unitOfWork.GetRepository<ComboAppointment>().InsertAsync(comboAppointment);
                }
            }

            // Add new appointment
            await _unitOfWork.GetRepository<Appointment>().InsertAsync(newAppointment);
            await _unitOfWork.SaveAsync();

            return "Appointment successfully created.";
        }

        // Get all appointments by startEndDay, id
        public async Task<BasePaginatedList<AppointmentModelView>> GetAllAppointmentAsync(int pageNumber, int pageSize, DateTime? startDate, DateTime? endDate, string? id, Guid? userId, Guid? stylistId, string? statusForAppointment)
        {
            // Get appointments from database
            IQueryable<Appointment> appointmentQuery = _unitOfWork.GetRepository<Appointment>().Entities
                .Where(p => !p.DeletedTime.HasValue)
                .OrderByDescending(s => s.CreatedTime);

            // Filter by date range if provided
            if (startDate.HasValue && endDate.HasValue)
            {
                appointmentQuery = appointmentQuery.Where(a => a.AppointmentDate >= startDate.Value && a.AppointmentDate <= endDate.Value);
            }

            // Filter by ID if provided
            if (!string.IsNullOrEmpty(id))
            {
                appointmentQuery = appointmentQuery.Where(a => a.Id.Equals(id));
            }

            if (userId.HasValue)
            {
                appointmentQuery = appointmentQuery.Where(p => p.UserId == userId.Value);
            }

            if (stylistId.HasValue)
            {
                appointmentQuery = appointmentQuery.Where(p => p.StylistId == stylistId.Value);
            }

            if (!string.IsNullOrEmpty(statusForAppointment))
            {
                appointmentQuery = appointmentQuery.Where(a => a.StatusForAppointment.Equals(statusForAppointment));
            }

            int totalCount = await appointmentQuery.CountAsync();

            // Apply pagination
            List<Appointment> paginatedAppointments = await appointmentQuery
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Map data to model
            List<AppointmentModelView> appointmentModelViews = _mapper.Map<List<AppointmentModelView>>(paginatedAppointments);
            foreach (var appointmentModelView in appointmentModelViews)
            {
                var user = await _unitOfWork.GetRepository<ApplicationUsers>().GetByIdAsync(Guid.Parse(appointmentModelView.UserId));
                appointmentModelView.UserName = user.UserName;
            }
            return new BasePaginatedList<AppointmentModelView>(appointmentModelViews, totalCount, pageNumber, pageSize);
        }


        // Update Appointment
        public async Task<string> UpdateAppointmentAsync(string id, UpdateAppointmentModelView model, string? userId)
        {
            if (userId == null)
            {
                userId = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
            }

            // Validate appointment ID
            if (string.IsNullOrWhiteSpace(id))
            {
                return "Invalid appointment ID. Please provide a valid ID.";
            }

            // Get the existing appointment by ID and ensure it's not deleted
            var existingAppointment = await _unitOfWork.GetRepository<Appointment>().Entities
                .FirstOrDefaultAsync(s => s.Id == id && !s.DeletedTime.HasValue);

            if (existingAppointment == null)
            {
                return "Appointment not found or has already been deleted.";
            }

            // Get current total time and total amount from existing services and combos
            int newTotalTime = existingAppointment.TotalTime;
            decimal newTotalAmount = existingAppointment.TotalAmount;

            // Handle update ServiceIds if any
            if (!model.ServiceIds.IsNullOrEmpty())
            {
                var updateResult = await UpdateServiceAppointmentsAsync(existingAppointment.Id, model.ServiceIds, newTotalTime, newTotalAmount, userId);
                newTotalTime = updateResult.TotalTime;
                newTotalAmount = updateResult.TotalAmount;
            }

            // Handle update ComboIds if any
            if (!model.ComboIds.IsNullOrEmpty())
            {
                var updateResult = await UpdateComboAppointmentsAsync(existingAppointment.Id, model.ComboIds, newTotalTime, newTotalAmount, userId);
                newTotalTime = updateResult.TotalTime;
                newTotalAmount = updateResult.TotalAmount;
            }

            // Update AppointmentDate if provided and valid
            if (model.AppointmentDate.HasValue)
            {
                if (model.AppointmentDate < DateTime.Now || model.AppointmentDate > DateTime.Now.AddMonths(1))
                {
                    return "Invalid appointment date. The date must be within one month from today.";
                }

                // Check for time conflicts when updating appointment dates
                if (await IsDuplicateAppointment((Guid)existingAppointment.UserId, (DateTime)model.AppointmentDate, newTotalTime, existingAppointment.Id))
                {
                    return "The new appointment time conflicts with another appointment.";
                }

                existingAppointment.AppointmentDate = model.AppointmentDate.Value;
            }

            // Update the StylistId if provided
            if (!string.IsNullOrWhiteSpace(model.StylistId) && Guid.TryParse(model.StylistId, out Guid newStylistId))
            {
                // Check if stylist is busy
                if (await IsStylistBusy(newStylistId, existingAppointment.AppointmentDate, newTotalTime, existingAppointment.Id))
                {
                    return "Stylist is busy at that time.";
                }
                existingAppointment.StylistId = newStylistId;
            }
            else
            {
                if (await IsStylistBusy((Guid)existingAppointment.StylistId, existingAppointment.AppointmentDate, newTotalTime, existingAppointment.Id))
                {
                    return "Stylist is busy at that time.";
                }
            }

            // Check if user has enough points
            var user = await _unitOfWork.GetRepository<ApplicationUsers>().GetByIdAsync(existingAppointment.UserId);
            if (model.PointsEarned > user.UserInfo.Point)
            {
                return "Insufficient points. The user does not have enough points for this appointment.";
            }

            if (model.PointsEarned.HasValue)
            {
                existingAppointment.PointsEarned = (int)model.PointsEarned;
            }

            // Update general appointment information
            existingAppointment.LastUpdatedBy = userId;
            existingAppointment.LastUpdatedTime = DateTimeOffset.UtcNow;
            existingAppointment.TotalTime = newTotalTime;
            existingAppointment.TotalAmount = newTotalAmount;

            // Save changes
            await _unitOfWork.GetRepository<Appointment>().UpdateAsync(existingAppointment);
            await _unitOfWork.SaveAsync();

            return "Appointment updated successfully.";
        }

        // update ServiceAppointment 
        private async Task<(int TotalTime, decimal TotalAmount)> UpdateServiceAppointmentsAsync(string appointmentId, string[] serviceIds, int currentTotalTime, decimal currentTotalAmount, string? userId)
        {
            if (userId == null)
            {
                userId = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
            }

            var existingServiceAppointments = await _unitOfWork.GetRepository<ServiceAppointment>().Entities
                .Where(sa => sa.AppointmentId == appointmentId && !sa.DeletedTime.HasValue).ToListAsync();

            // Delete services that are no longer in the new list
            var servicesToRemove = existingServiceAppointments.Where(sa => !serviceIds.Contains(sa.ServiceId)).ToList();
            foreach (var serviceAppointment in servicesToRemove)
            {
                serviceAppointment.DeletedTime = DateTimeOffset.UtcNow;
                serviceAppointment.DeletedBy = userId;
                var service = (await _unitOfWork.GetRepository<HairSalon.Contract.Repositories.Entity.Service>().GetByIdAsync(serviceAppointment.ServiceId));
                currentTotalTime -= service.TimeService;
                currentTotalAmount -= service.Price;
            }

            // Add new serviceAppointment
            var currentServiceIds = existingServiceAppointments.Select(sa => sa.ServiceId).ToList();
            var servicesToAdd = serviceIds.Where(s => !currentServiceIds.Contains(s)).ToList();
            foreach (var serviceId in servicesToAdd)
            {
                var serviceAppointment = new ServiceAppointment
                {
                    ServiceId = serviceId,
                    AppointmentId = appointmentId,
                    LastUpdatedTime = DateTimeOffset.UtcNow,
                    LastUpdatedBy = userId
                };
                await _unitOfWork.GetRepository<ServiceAppointment>().InsertAsync(serviceAppointment);
                var service = (await _unitOfWork.GetRepository<HairSalon.Contract.Repositories.Entity.Service>().GetByIdAsync(serviceId));
                currentTotalTime += service.TimeService;
                currentTotalAmount += service.Price;
            }

            return (currentTotalTime, currentTotalAmount);
        }

        // update ComboAppointment 
        private async Task<(int TotalTime, decimal TotalAmount)> UpdateComboAppointmentsAsync(string appointmentId, string[] comboIds, int currentTotalTime, decimal currentTotalAmount, string? userId)
        {
            if (userId == null)
            {
                userId = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
            }

            var existingComboAppointments = await _unitOfWork.GetRepository<ComboAppointment>().Entities
                .Where(ca => ca.AppointmentId == appointmentId && !ca.DeletedTime.HasValue).ToListAsync();

            // Delete combos that are no longer in the new list
            var combosToRemove = existingComboAppointments.Where(ca => !comboIds.Contains(ca.ComboId)).ToList();
            foreach (var comboAppointment in combosToRemove)
            {
                comboAppointment.DeletedTime = DateTimeOffset.UtcNow;
                comboAppointment.DeletedBy = userId;
                var combo = await _unitOfWork.GetRepository<Combo>().GetByIdAsync(comboAppointment.ComboId);
                currentTotalTime -= combo.TimeCombo;
                currentTotalAmount -= combo.TotalPrice;
            }

            // Add new comboAppointment
            var currentComboIds = existingComboAppointments.Select(ca => ca.ComboId).ToList();
            var combosToAdd = comboIds.Where(c => !currentComboIds.Contains(c)).ToList();
            foreach (var comboId in combosToAdd)
            {
                var comboAppointment = new ComboAppointment
                {
                    ComboId = comboId,
                    AppointmentId = appointmentId,
                    LastUpdatedTime = DateTimeOffset.UtcNow,
                    LastUpdatedBy = userId
                };
                await _unitOfWork.GetRepository<ComboAppointment>().InsertAsync(comboAppointment);
                var combo = (await _unitOfWork.GetRepository<Combo>().GetByIdAsync(comboId));
                currentTotalTime += combo.TimeCombo;
                currentTotalAmount += combo.TotalPrice;
            }

            return (currentTotalTime, currentTotalAmount);
        }

        // Delete an appointment
        public async Task<string> DeleteAppointmentAsync(string id, string? userId)
        {
            if (userId == null)
            {
                userId = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
            }

            // Validate appointment ID
            if (string.IsNullOrWhiteSpace(id))
            {
                return "Invalid appointment ID. Please provide a valid ID.";
            }

            // Get appointment by ID and ensure it's not deleted
            var existingAppointment = await _unitOfWork.GetRepository<Appointment>().Entities
                .FirstOrDefaultAsync(s => s.Id == id && !s.DeletedTime.HasValue);

            if (existingAppointment == null)
            {
                return "Appointment not found or has already been deleted.";
            }

            // Soft delete appointment
            existingAppointment.DeletedTime = DateTimeOffset.UtcNow;
            existingAppointment.DeletedBy = userId;
            existingAppointment.StatusForAppointment = "Cancelled";

            // Get all related ServiceAppointments
            var relatedServiceAppointments = await _unitOfWork.GetRepository<ServiceAppointment>().Entities
                .Where(sa => sa.AppointmentId == id).ToListAsync();

            // Soft delete each ServiceAppointment
            foreach (var serviceAppointment in relatedServiceAppointments)
            {
                serviceAppointment.DeletedTime = DateTimeOffset.UtcNow;
                serviceAppointment.DeletedBy = userId;

                await _unitOfWork.GetRepository<ServiceAppointment>().UpdateAsync(serviceAppointment);
            }

            // Get all related ComboAppointment
            var relatedComboAppointments = await _unitOfWork.GetRepository<ComboAppointment>().Entities
                .Where(c => c.AppointmentId == id).ToListAsync();

            // Soft delete each ComboAppointment
            foreach (var comboAppointment in relatedComboAppointments)
            {
                comboAppointment.DeletedTime = DateTimeOffset.UtcNow;
                comboAppointment.DeletedBy = userId;

                await _unitOfWork.GetRepository<ComboAppointment>().UpdateAsync(comboAppointment);
            }

            // Save changes
            await _unitOfWork.GetRepository<Appointment>().UpdateAsync(existingAppointment);
            await _unitOfWork.SaveAsync();

            return "Appointment deleted successfully.";
        }

        // Mark Appointment Completed
        public async Task<string> MarkCompleted(string id, string? userId)
        {
            // Validate appointment ID
            if (string.IsNullOrWhiteSpace(id))
            {
                return "Invalid appointment ID. Please provide a valid ID.";
            }

            // Get appointment by ID and ensure it's not deleted
            var existingAppointment = await _unitOfWork.GetRepository<Appointment>().Entities
                .FirstOrDefaultAsync(s => s.Id == id && !s.DeletedTime.HasValue);

            if (existingAppointment == null)
            {
                return "Appointment not found or has already been deleted.";
            }

            // set status Completed and save
            existingAppointment.StatusForAppointment = "Completed";
            if (userId != null)
            {
                existingAppointment.LastUpdatedBy = userId;
            }
            else
            {
                existingAppointment.LastUpdatedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
            }
            existingAppointment.LastUpdatedTime = DateTimeOffset.UtcNow;
            await _unitOfWork.SaveAsync();

            return "success";
        }

        // Mark Appointment Confirmed
        public async Task<string> MarkConfirmed(string id, string? userId)
        {
            // Validate appointment ID
            if (string.IsNullOrWhiteSpace(id))
            {
                return "Invalid appointment ID. Please provide a valid ID.";
            }

            // Get appointment by ID and ensure it's not deleted
            var existingAppointment = await _unitOfWork.GetRepository<Appointment>().Entities
                .FirstOrDefaultAsync(s => s.Id == id && !s.DeletedTime.HasValue);

            if (existingAppointment == null)
            {
                return "Appointment not found or has already been deleted.";
            }

            // Fetch user and user info
            var applicationUser = await _unitOfWork.GetRepository<ApplicationUsers>().Entities
                .FirstOrDefaultAsync(u => u.Id == existingAppointment.UserId);
            if (applicationUser == null)
            {
                return "User not found in ApplicationUsers.";
            }

            var userInfo = await _unitOfWork.GetRepository<UserInfo>().Entities
                .FirstOrDefaultAsync(ui => ui.Id == applicationUser.UserInfo.Id);
            if (userInfo == null)
            {
                return "User info not found.";
            }

            // Calculate points earned from the original total amount
            userInfo.Point -= existingAppointment.PointsEarned;
            int pointsToAdd = (int)(existingAppointment.TotalAmount / 1000) * 10;
            userInfo.Point += pointsToAdd;
            await _unitOfWork.GetRepository<UserInfo>().UpdateAsync(userInfo);

            // Calculate the final total amount after applying discount
            existingAppointment.TotalAmount -= existingAppointment.PointsEarned;

            // set status Confirmed and save
            existingAppointment.StatusForAppointment = "Confirmed";
            if (userId != null)
            {
                existingAppointment.LastUpdatedBy = userId;
            }
            else
            {
                existingAppointment.LastUpdatedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
            }
            existingAppointment.LastUpdatedTime = DateTimeOffset.UtcNow;
            await _unitOfWork.SaveAsync();

            return "success";
        }

        // Retrieve a appointment by its ID
        public async Task<AppointmentModelView?> GetAppointmentByIdAsync(string id)
        {
            // Check if the provided Appointment ID is valid (non-empty and non-whitespace)
            if (string.IsNullOrWhiteSpace(id))
            {
                return null;
            }

            // Try to find the appointment by its ID, ensuring it hasn’t been marked as deleted
            var appointmentEntity = await _unitOfWork.GetRepository<Appointment>().Entities
                .FirstOrDefaultAsync(a => a.Id == id && !a.DeletedTime.HasValue);

            // If the appointment is not found, return null
            if (appointmentEntity == null)
            {
                return null;
            }

            // Map the Appointment entity to a AppointmentModelView and return it
            AppointmentModelView appointmentModelView = _mapper.Map<AppointmentModelView>(appointmentEntity);
            return appointmentModelView;
        }

        public async Task<List<ServiceAppointment>> GetAllServiceAppointment(string appointmentId)
        {
            List<ServiceAppointment> list = _unitOfWork.GetRepository<ServiceAppointment>().Entities
                                                                .Where(s => s.AppointmentId == appointmentId && !s.DeletedTime.HasValue)
                                                                .ToList();
            return list;
        }

        public async Task<List<ComboAppointment>> GetAllComboAppointment(string appointmentId)
        {
            List<ComboAppointment> list = _unitOfWork.GetRepository<ComboAppointment>().Entities
                                                                .Where(s => s.AppointmentId == appointmentId && !s.DeletedTime.HasValue)
                                                                .ToList();
            return list;
        }


        public async Task<List<AppointmentModelView>> GetAppointmentsForDropdownAsync()
        {
            // L?y t?t c? appointments t? repository
            var appointments = await _unitOfWork.GetRepository<Appointment>().Entities
                .Where(a => !a.DeletedTime.HasValue) // Ch? l?y các appointment ch?a b? xóa
                .ToListAsync();

            if (appointments == null || !appointments.Any())
            {
                return new List<AppointmentModelView>();
            }

            // Chuy?n ??i sang AppointmentModelView
            return _mapper.Map<List<AppointmentModelView>>(appointments);
        }
        public async Task<List<AppointmentModelView>> GetAppointmentsByUserIdAsync(string userId)
        {
            // If userId is not provided or is invalid, throw an exception
            if (string.IsNullOrEmpty(userId) || !Guid.TryParse(userId, out Guid userGuid))
            {
                throw new ArgumentException("A valid userId must be provided.");
            }

            // Query appointments where the userId matches and StatusForAppointment is 'Completed', excluding deleted appointments
            var appointments = await _unitOfWork.GetRepository<Appointment>().Entities
                .Where(a => a.UserId == userGuid && // Filter by userId
                            a.StatusForAppointment == "Completed" && // Filter by Completed status
                            !a.DeletedTime.HasValue) // Only include non-deleted appointments
                .ToListAsync();

            if (appointments == null || !appointments.Any())
            {
                return new List<AppointmentModelView>();
            }

            // Map the results to AppointmentModelView
            return _mapper.Map<List<AppointmentModelView>>(appointments);
        }

    }
}