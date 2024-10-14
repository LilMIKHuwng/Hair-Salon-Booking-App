using AutoMapper;
using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Repositories.Interface;
using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.ModelViews.AppointmentModelViews;
using HairSalon.Repositories.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

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

            // Get the user by userId
            var user = await _unitOfWork.GetRepository<ApplicationUsers>().GetByIdAsync(Guid.Parse(model.UserId));

            // Check if user has enough points
            if (model.PointsEarned > user.UserInfo.Point)
            {
                return "Insufficient points. The user does not have enough points for this appointment.";
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

                // calculate total time of appointment
                var service = await _unitOfWork.GetRepository<HairSalon.Contract.Repositories.Entity.Service>().GetByIdAsync(serviceId);
                newAppointment.TotalTime += service.TimeService;

                // Add each ServiceAppointment to the repository
                await _unitOfWork.GetRepository<ServiceAppointment>().InsertAsync(serviceAppointment);
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

            // If UserId is not null, validate user and points
            if (!string.IsNullOrWhiteSpace(model.UserId))
            {
                ApplicationUsers user = await _unitOfWork.GetRepository<ApplicationUsers>().GetByIdAsync(Guid.Parse(model.UserId));

                existingAppointment.UserId = user.Id;
            }

            if (model.PointsEarned.HasValue)
            {
                // Check if the user has enough points, if PointsEarned is being updated
                if (model.PointsEarned > existingAppointment.User.UserInfo.Point)
                {
                    return "Insufficient points. The user does not have enough points for this appointment.";
                }
                existingAppointment.PointsEarned = model.PointsEarned.Value;
            }

            // Update the StylistId if provided
            if (!string.IsNullOrWhiteSpace(model.StylistId) && Guid.TryParse(model.StylistId, out Guid newStylistId))
            {
                existingAppointment.StylistId = newStylistId;
            }

            // Update the StatusForAppointment if provided
            if (!string.IsNullOrWhiteSpace(model.StatusForAppointment))
            {
                existingAppointment.StatusForAppointment = model.StatusForAppointment;
            }

            // Update AppointmentDate if provided and valid
            if (model.AppointmentDate.HasValue)
            {
                if (model.AppointmentDate < DateTime.Now || model.AppointmentDate > DateTime.Now.AddMonths(1))
                {
                    return "Invalid appointment date. The date must be within one month from today.";
                }
                existingAppointment.AppointmentDate = model.AppointmentDate.Value;
            }

            // Update LastUpdatedBy and LastUpdatedTime
            existingAppointment.LastUpdatedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
            existingAppointment.LastUpdatedTime = DateTimeOffset.UtcNow;

            // Save changes
            await _unitOfWork.GetRepository<Appointment>().UpdateAsync(existingAppointment);
            await _unitOfWork.SaveAsync();

            return "Appointment updated successfully.";
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
            existingAppointment.StatusForAppointment = "Deleted";

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

            // set status Completed
            existingAppointment.StatusForAppointment = "Completed";
            existingAppointment.LastUpdatedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
            existingAppointment.LastUpdatedTime = DateTimeOffset.UtcNow;

            return "success";
        }
    }
}
