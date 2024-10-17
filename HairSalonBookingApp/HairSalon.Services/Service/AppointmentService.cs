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

        // Add a new appointment
        public async Task<string> AddAppointmentAsync(CreateAppointmentModelView model)
        {
            // Validate appointment date
            if (model.AppointmentDate < DateTime.Now || model.AppointmentDate > DateTime.Now.AddMonths(1))
            {
                return "Invalid appointment date. The date must be within one month from today.";
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

            // Get the user by userId
            var user = await _unitOfWork.GetRepository<ApplicationUsers>().GetByIdAsync(Guid.Parse(model.UserId));
            if (user == null)
            {
                return "User is not found.";
            }

            // Check if user has enough points
            if (model.PointsEarned > user.UserInfo.Point)
            {
                return "Insufficient points. The user does not have enough points for this appointment.";
            }

            // Check if stylist exists
            var stylist = await _unitOfWork.GetRepository<ApplicationUsers>().GetByIdAsync(Guid.Parse(model.StylistId));
            if (stylist == null)
            {
                return "Stylist is not found.";
            }

            // check stylist don't have any appointment
            bool isStylistBusy = await _unitOfWork.GetRepository<Appointment>().Entities
                .AnyAsync(p => p.StylistId == Guid.Parse(model.StylistId)
                    && p.StatusForAppointment.Equals("Scheduled")
                    && model.AppointmentDate < p.AppointmentDate.AddMinutes(p.TotalTime)
                    && model.AppointmentDate >= p.AppointmentDate
                    && !p.DeletedTime.HasValue);

            if (isStylistBusy)
            {
                return "Stylist is busy at that time";
            }

            // Map data model to entity
            Appointment newAppointment = _mapper.Map<Appointment>(model);
            newAppointment.Id = Guid.NewGuid().ToString("N");
            newAppointment.StatusForAppointment = "Scheduled";
            newAppointment.CreatedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
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
                        CreatedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value,
                        CreatedTime = DateTimeOffset.UtcNow,
                        LastUpdatedTime = DateTimeOffset.UtcNow
                    };

                    // calculate total time and total amount of appointment
                    var service = await _unitOfWork.GetRepository<HairSalon.Contract.Repositories.Entity.Service>().GetByIdAsync(serviceId);
                    newAppointment.TotalTime += service.TimeService;
                    newAppointment.TotalAmount += service.Price;

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
                        CreatedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value,
                        CreatedTime = DateTimeOffset.UtcNow,
                        LastUpdatedTime = DateTimeOffset.UtcNow
                    };

                    // calculate total time and total amount of appointment
                    var combo = await _unitOfWork.GetRepository<Combo>().GetByIdAsync(comboId);
                    newAppointment.TotalTime += combo.TimeCombo;
                    newAppointment.TotalAmount += combo.TotalPrice;

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
        public async Task<BasePaginatedList<AppointmentModelView>> GetAllAppointmentAsync(int pageNumber, int pageSize, DateTime? startDate, DateTime? endDate, string? id)
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

            int totalCount = await appointmentQuery.CountAsync();

            // Apply pagination
            List<Appointment> paginatedAppointments = await appointmentQuery
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Map data to model
            List<AppointmentModelView> appointmentModelViews = _mapper.Map<List<AppointmentModelView>>(paginatedAppointments);

            return new BasePaginatedList<AppointmentModelView>(appointmentModelViews, totalCount, pageNumber, pageSize);
        }


        // Update Appointment
        public async Task<string> UpdateAppointmentAsync(string id, UpdateAppointmentModelView model)
        {
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

            int newTotalTime = existingAppointment.TotalTime; // get current total time 
            decimal newTotalAmount = existingAppointment.TotalAmount;

            // Update the StylistId if provided
            if (!string.IsNullOrWhiteSpace(model.StylistId) && Guid.TryParse(model.StylistId, out Guid newStylistId))
            {
                // Check is stylist busy 
                if (await IsStylistBusyAsync(newStylistId, existingAppointment.AppointmentDate, newTotalTime, existingAppointment.Id))
                {
                    return "Stylist is busy at that time.";
                }
                existingAppointment.StylistId = newStylistId;
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

            // Update AppointmentDate if provided and valid
            if (model.AppointmentDate.HasValue)
            {
                if (model.AppointmentDate < DateTime.Now || model.AppointmentDate > DateTime.Now.AddMonths(1))
                {
                    return "Invalid appointment date. The date must be within one month from today.";
                }

                // Check for time conflicts when updating appointment dates
                if (await CheckAppointmentOverlappingAsync(existingAppointment.Id, existingAppointment.StylistId, model.AppointmentDate.Value, newTotalTime))
                {
                    return "The new appointment time conflicts with another appointment.";
                }

                existingAppointment.AppointmentDate = model.AppointmentDate.Value;
            }

            // Handle update ServiceIds if any
            if (model.ServiceIds != null && model.ServiceIds.Length > 0)
            {
                var updateResult = await UpdateServiceAppointmentsAsync(existingAppointment.Id, model.ServiceIds, newTotalTime, newTotalAmount);
                newTotalTime = updateResult.TotalTime;
                newTotalAmount = updateResult.TotalAmount;
            }

            // Process update ComboIds if any
            if (model.ComboIds != null && model.ComboIds.Length > 0)
            {
                var updateResult = await UpdateComboAppointmentsAsync(existingAppointment.Id, model.ComboIds, newTotalTime, newTotalAmount);
                newTotalTime = updateResult.TotalTime;
                newTotalAmount = updateResult.TotalAmount;
            }

            // Check if the appointment after update overlaps
            if (await CheckAppointmentOverlappingAsync(existingAppointment.Id, existingAppointment.StylistId, existingAppointment.AppointmentDate, newTotalTime))
            {
                return "The updated appointment time conflicts with another appointment.";
            }

            // Update general appointment information
            existingAppointment.LastUpdatedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
            existingAppointment.LastUpdatedTime = DateTimeOffset.UtcNow;
            existingAppointment.TotalTime = newTotalTime;
            existingAppointment.TotalAmount = newTotalAmount;

            // Save changes
            await _unitOfWork.GetRepository<Appointment>().UpdateAsync(existingAppointment);
            await _unitOfWork.SaveAsync();

            return "Appointment updated successfully.";
        }

        private async Task<bool> IsStylistBusyAsync(Guid stylistId, DateTime appointmentDate, int totalTime, string? currentAppointmentId = null)
        {
            return await _unitOfWork.GetRepository<Appointment>().Entities
                .AnyAsync(p => p.StylistId == stylistId
                    && p.StatusForAppointment == "Scheduled"
                    && !p.DeletedTime.HasValue
                    && (currentAppointmentId == null || p.Id != currentAppointmentId)
                    && (appointmentDate < p.AppointmentDate.AddMinutes(p.TotalTime))
                    && (appointmentDate.AddMinutes(totalTime) > p.AppointmentDate));
        }

        private async Task<bool> CheckAppointmentOverlappingAsync(string appointmentId, Guid? stylistId, DateTime newAppointmentDate, int newTotalTime)
        {
            var appointments = await _unitOfWork.GetRepository<Appointment>().Entities
                .Where(a => a.StylistId == stylistId && a.Id != appointmentId && !a.DeletedTime.HasValue)
                .ToListAsync();

            foreach (var appt in appointments)
            {
                var apptEndTime = appt.AppointmentDate.AddMinutes(appt.TotalTime);
                var newApptEndTime = newAppointmentDate.AddMinutes(newTotalTime);

                if ((newAppointmentDate < apptEndTime && newApptEndTime > appt.AppointmentDate))
                {
                    return true;
                }
            }
            return false;
        }

        private async Task<(int TotalTime, decimal TotalAmount)> UpdateServiceAppointmentsAsync(string appointmentId, string[] serviceIds, int currentTotalTime, decimal currentTotalAmount)
        {
            var existingServiceAppointments = await _unitOfWork.GetRepository<ServiceAppointment>().Entities
                .Where(sa => sa.AppointmentId == appointmentId && !sa.DeletedTime.HasValue).ToListAsync();

            // Delete services that are no longer in the new list
            var servicesToRemove = existingServiceAppointments.Where(sa => !serviceIds.Contains(sa.ServiceId)).ToList();
            foreach (var serviceAppointment in servicesToRemove)
            {
                serviceAppointment.DeletedTime = DateTimeOffset.UtcNow;
                serviceAppointment.DeletedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
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
                    LastUpdatedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value
                };
                await _unitOfWork.GetRepository<ServiceAppointment>().InsertAsync(serviceAppointment);
                var service = (await _unitOfWork.GetRepository<HairSalon.Contract.Repositories.Entity.Service>().GetByIdAsync(serviceId));
                currentTotalTime += service.TimeService;
                currentTotalAmount += service.Price;
            }

            return (currentTotalTime, currentTotalAmount);
        }

        private async Task<(int TotalTime, decimal TotalAmount)> UpdateComboAppointmentsAsync(string appointmentId, string[] comboIds, int currentTotalTime, decimal currentTotalAmount)
        {
            var existingComboAppointments = await _unitOfWork.GetRepository<ComboAppointment>().Entities
                .Where(ca => ca.AppointmentId == appointmentId && !ca.DeletedTime.HasValue).ToListAsync();

            var combosToRemove = existingComboAppointments.Where(ca => !comboIds.Contains(ca.ComboId)).ToList();
            foreach (var comboAppointment in combosToRemove)
            {
                comboAppointment.DeletedTime = DateTimeOffset.UtcNow;
                comboAppointment.DeletedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
                var combo = await _unitOfWork.GetRepository<Combo>().GetByIdAsync(comboAppointment.ComboId);
                currentTotalTime -= combo.TimeCombo;
                currentTotalAmount -= combo.TotalPrice;
            }

            var currentComboIds = existingComboAppointments.Select(ca => ca.ComboId).ToList();
            var combosToAdd = comboIds.Where(c => !currentComboIds.Contains(c)).ToList();
            foreach (var comboId in combosToAdd)
            {
                var comboAppointment = new ComboAppointment
                {
                    ComboId = comboId,
                    AppointmentId = appointmentId,
                    LastUpdatedTime = DateTimeOffset.UtcNow,
                    LastUpdatedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value
                };
                await _unitOfWork.GetRepository<ComboAppointment>().InsertAsync(comboAppointment);
                var combo = (await _unitOfWork.GetRepository<Combo>().GetByIdAsync(comboId));
                currentTotalTime += combo.TimeCombo;
                currentTotalAmount += combo.TotalPrice;
            }

            return (currentTotalTime, currentTotalAmount);
        }



        // Delete an appointment
        public async Task<string> DeleteAppointmentAsync(string id)
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

            // Soft delete appointment
            existingAppointment.DeletedTime = DateTimeOffset.UtcNow;
            existingAppointment.DeletedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
            existingAppointment.StatusForAppointment = "Cancelled";

            // Get all related ServiceAppointments
            var relatedServiceAppointments = await _unitOfWork.GetRepository<ServiceAppointment>().Entities
                .Where(sa => sa.AppointmentId == id).ToListAsync();

            // Soft delete each ServiceAppointment
            foreach (var serviceAppointment in relatedServiceAppointments)
            {
                serviceAppointment.DeletedTime = DateTimeOffset.UtcNow;
                serviceAppointment.DeletedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;

                await _unitOfWork.GetRepository<ServiceAppointment>().UpdateAsync(serviceAppointment);
            }

            // Get all related ComboAppointment
            var relatedComboAppointments = await _unitOfWork.GetRepository<ComboAppointment>().Entities
                .Where(c => c.AppointmentId == id).ToListAsync();

            // Soft delete each ComboAppointment
            foreach (var comboAppointment in relatedComboAppointments)
            {
                comboAppointment.DeletedTime = DateTimeOffset.UtcNow;
                comboAppointment.DeletedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;

                await _unitOfWork.GetRepository<ComboAppointment>().UpdateAsync(comboAppointment);
            }

            // Save changes
            await _unitOfWork.GetRepository<Appointment>().UpdateAsync(existingAppointment);
            await _unitOfWork.SaveAsync();

            return "Appointment deleted successfully.";
        }

        // Mark Appointment Completed
        public async Task<string> MarkCompleted(string id)
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
            existingAppointment.LastUpdatedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
            existingAppointment.LastUpdatedTime = DateTimeOffset.UtcNow;
            await _unitOfWork.SaveAsync();

            return "success";
        }

        // Mark Appointment Confirmed
        public async Task<string> MarkConfirmed(string id)
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
            existingAppointment.LastUpdatedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
            existingAppointment.LastUpdatedTime = DateTimeOffset.UtcNow;
            await _unitOfWork.SaveAsync();

            return "success";
        }
    }
}
