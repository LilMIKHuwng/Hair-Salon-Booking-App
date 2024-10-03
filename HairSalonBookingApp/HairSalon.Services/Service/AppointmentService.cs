using AutoMapper;
using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Repositories.Interface;
using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.ModelViews.AppointmentModelViews;
using Microsoft.EntityFrameworkCore;

namespace HairSalon.Services.Service
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AppointmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AppointmentModelView> AddAppointmentAsync(CreateAppointmentModelView model)
        {
            Appointment newAppointment = _mapper.Map<Appointment>(model);

            newAppointment.Id = Guid.NewGuid().ToString("N");
            newAppointment.CreatedBy = "claim account";  
            newAppointment.CreatedTime = DateTimeOffset.UtcNow;
            newAppointment.LastUpdatedTime = DateTimeOffset.UtcNow;

            await _unitOfWork.GetRepository<Appointment>().InsertAsync(newAppointment);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<AppointmentModelView>(newAppointment);
        }

        public async Task<BasePaginatedList<AppointmentModelView>> GetAllAppointmentAsync(int pageNumber, int pageSize)
        {
            IQueryable<Appointment> appointmentQuery = _unitOfWork.GetRepository<Appointment>().Entities
                .Where(p => !p.DeletedTime.HasValue)
                .OrderByDescending(s => s.CreatedTime);

            int totalCount = await appointmentQuery.CountAsync();

            List<Appointment> paginatedAppointments = await appointmentQuery
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            List<AppointmentModelView> appointmentModelViews = _mapper.Map<List<AppointmentModelView>>(paginatedAppointments);

            return new BasePaginatedList<AppointmentModelView>(appointmentModelViews, totalCount, pageNumber, pageSize);
        }

        public async Task<AppointmentModelView> GetAppointmentAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new Exception("Please provide a valid Appointment ID.");
            }

            Appointment existingAppointment = await _unitOfWork.GetRepository<Appointment>().Entities
                .FirstOrDefaultAsync(s => s.Id == id && !s.DeletedTime.HasValue)
                ?? throw new Exception("The Appointment cannot be found or has been deleted!");

            return _mapper.Map<AppointmentModelView>(existingAppointment);
        }

        public async Task<AppointmentModelView> UpdateAppointmentAsync(string id, UpdateAppointmentModelView model)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new Exception("Please provide a valid Appointment ID.");
            }

            Appointment existingAppointment = await _unitOfWork.GetRepository<Appointment>().Entities
                .FirstOrDefaultAsync(s => s.Id == id && !s.DeletedTime.HasValue)
                ?? throw new Exception("The Appointment cannot be found or has been deleted!");

            _mapper.Map(model, existingAppointment);

            existingAppointment.LastUpdatedBy = "claim account"; 
            existingAppointment.LastUpdatedTime = DateTimeOffset.UtcNow;

            _unitOfWork.GetRepository<Appointment>().Update(existingAppointment);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<AppointmentModelView>(existingAppointment);
        }


        public async Task<string> DeleteAppointmentAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new Exception("Please provide a valid Appointment ID.");
            }

            Appointment existingAppointment = await _unitOfWork.GetRepository<Appointment>().Entities
                .FirstOrDefaultAsync(s => s.Id == id && !s.DeletedTime.HasValue)
                ?? throw new Exception("The Appointment cannot be found or has been deleted!");

            existingAppointment.DeletedTime = DateTimeOffset.UtcNow;
            existingAppointment.DeletedBy = "claim account"; 

            _unitOfWork.GetRepository<Appointment>().Update(existingAppointment);
            await _unitOfWork.SaveAsync();
            return "Deleted";
        }
    }
}
