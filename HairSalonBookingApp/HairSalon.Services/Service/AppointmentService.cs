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

        //Add new appointment
        public async Task<string> AddAppointmentAsync(CreateAppointmentModelView model)
        {
            try
            {
                //map data model to entity
                if (model.AppointmentDate < DateTime.Now || model.AppointmentDate > DateTime.Now.AddMonths(1))
                {
                    throw new Exception("Appointment date cannot be in the past or more than 1 month in the future");
                }

                var user = await _unitOfWork.GetRepository<ApplicationUsers>().GetByIdAsync(Guid.Parse(model.UserId));
                if (model.PointsEarned > user.UserInfo.Point)
                {
                    throw new Exception("User point not enough");
                }

                Appointment newAppointment = _mapper.Map<Appointment>(model);

                newAppointment.Id = Guid.NewGuid().ToString("N");
                newAppointment.CreatedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
                newAppointment.CreatedTime = DateTimeOffset.UtcNow;
                newAppointment.LastUpdatedTime = DateTimeOffset.UtcNow;

                //add new appointment
                await _unitOfWork.GetRepository<Appointment>().InsertAsync(newAppointment);
                await _unitOfWork.SaveAsync();

                return "Success";
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while adding an appointment.: {ex.Message}", ex);
            }
        }

        //find all appointment by startEndDay, id 
        public async Task<BasePaginatedList<AppointmentModelView>> GetAllAppointmentAsync(int pageNumber, int pageSize, DateTime? startDate, DateTime? endDate, string? id)
        {
            try
            {
                //get appointment from database 
                IQueryable<Appointment> appointmentQuery = _unitOfWork.GetRepository<Appointment>().Entities
                    .Where(p => !p.DeletedTime.HasValue)
                    .OrderByDescending(s => s.CreatedTime);

                // check time
                if (startDate.HasValue && endDate.HasValue)
                {
                    appointmentQuery = appointmentQuery.Where(a => a.AppointmentDate >= startDate.Value);
                    appointmentQuery = appointmentQuery.Where(a => a.AppointmentDate <= endDate.Value);
                }

                // check id
                if (!string.IsNullOrEmpty(id))
                {
                    appointmentQuery = appointmentQuery.Where(a => a.Id.Equals(id));
                }

                int totalCount = await appointmentQuery.CountAsync();

                //phan trang
                List<Appointment> paginatedAppointments = await appointmentQuery
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                //map data entity to model
                List<AppointmentModelView> appointmentModelViews = _mapper.Map<List<AppointmentModelView>>(paginatedAppointments);

                return new BasePaginatedList<AppointmentModelView>(appointmentModelViews, totalCount, pageNumber, pageSize);
            }
            catch(Exception ex)
            {
                throw new Exception($"An error occurred while get all appointments.: {ex.Message}", ex);
            }
        }

        //update appointment
        public async Task<string> UpdateAppointmentAsync(string id, UpdateAppointmentModelView model)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id))
                {
                    throw new Exception("Please provide a valid Appointment ID.");
                }

                //get appointment by id and not deleted 
                Appointment existingAppointment = await _unitOfWork.GetRepository<Appointment>().Entities
                    .FirstOrDefaultAsync(s => s.Id == id && !s.DeletedTime.HasValue)
                    ?? throw new Exception("The Appointment cannot be found or has been deleted!");

                // check point
                var user = await _unitOfWork.GetRepository<ApplicationUsers>().GetByIdAsync(Guid.Parse(model.UserId));
                if (model.PointsEarned > user.UserInfo.Point)
                {
                    throw new Exception("User point not enough");
                }

                //Map new data 
                if (model.AppointmentDate < DateTime.Now || model.AppointmentDate > DateTime.Now.AddMonths(1))
                {
                    throw new Exception("Appointment date cannot be in the past or more than 1 month in the future");
                }

                if (Guid.TryParse(model.StylistId, out Guid newStylistId) && newStylistId != existingAppointment.StylistId)
                {
                    existingAppointment.StylistId = newStylistId;
                }
                existingAppointment.StatusForAppointment = model.StatusForAppointment != existingAppointment.StatusForAppointment
                    ? model.StatusForAppointment
                    : existingAppointment.StatusForAppointment;

                existingAppointment.PointsEarned = model.PointsEarned != existingAppointment.PointsEarned
                    ? model.PointsEarned
                    : existingAppointment.PointsEarned;

                existingAppointment.AppointmentDate = model.AppointmentDate != existingAppointment.AppointmentDate
                    ? model.AppointmentDate
                    : existingAppointment.AppointmentDate;

                existingAppointment.AppointmentDate = model.AppointmentDate != existingAppointment.AppointmentDate
                    ? model.AppointmentDate
                    : existingAppointment.AppointmentDate;

                //set updateTime and updateBy
                existingAppointment.LastUpdatedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
                existingAppointment.LastUpdatedTime = DateTimeOffset.UtcNow;

                //save
                await _unitOfWork.GetRepository<Appointment>().UpdateAsync(existingAppointment);
                await _unitOfWork.SaveAsync();

                return "Sucess";
            }
            catch(Exception ex)
            {
                throw new Exception($"An error occurred while updating appointment.: {ex.Message}", ex);
            }
        }

        //delete appointment
        public async Task<string> DeleteAppointmentAsync(string id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id))
                {
                    throw new Exception("Please provide a valid Appointment ID.");
                }

                //get appointment by id and not deleted
                Appointment existingAppointment = await _unitOfWork.GetRepository<Appointment>().Entities
                    .FirstOrDefaultAsync(s => s.Id == id && !s.DeletedTime.HasValue)
                    ?? throw new Exception("The Appointment cannot be found or has been deleted!");

                //set deleteTime and deleteBy
                existingAppointment.DeletedTime = DateTimeOffset.UtcNow;
                existingAppointment.DeletedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;

                //save
                await _unitOfWork.GetRepository<Appointment>().UpdateAsync(existingAppointment);
                await _unitOfWork.SaveAsync();
                return "Deleted";
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while deleting appointment.: {ex.Message}", ex);
            }
        }
    }
}
