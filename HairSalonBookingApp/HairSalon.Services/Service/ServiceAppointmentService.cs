using AutoMapper;
using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Repositories.Interface;
using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.ModelViews.ServiceAppointmentModelViews;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace HairSalon.Services.Service;

public class ServiceAppointmentService : IServiceAppointment
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _contextAccessor;
    public ServiceAppointmentService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor contextAccessor)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _contextAccessor = contextAccessor;
    }

    public async Task<BasePaginatedList<ServiceAppointmentModelView>> GetAllServiceAppointment(int pageNumber, int pageSize, string? serviceId, string? appointmentId)
    {
        try
        {
            //get service appointment from database 
            IQueryable<ServiceAppointment> serviceAppointmentQuery = _unitOfWork.GetRepository<ServiceAppointment>().Entities
                .Where(p => !p.DeletedTime.HasValue)
                .OrderByDescending(s => s.CreatedTime);

            // check serviceId
            if (!string.IsNullOrEmpty(serviceId))
            {
                serviceAppointmentQuery = serviceAppointmentQuery.Where(a => a.ServiceId.Equals(serviceId));
            }

            // check appointmentId
            if (!string.IsNullOrEmpty(appointmentId))
            {
                serviceAppointmentQuery = serviceAppointmentQuery.Where(a => a.AppointmentId.Equals(appointmentId));
            }

            int totalCount = await serviceAppointmentQuery.CountAsync();

            //phan trang
            List<ServiceAppointment> paginated = await serviceAppointmentQuery
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            //map data entity to model
            List<ServiceAppointmentModelView> serviceAppointmentModelViews = _mapper.Map<List<ServiceAppointmentModelView>>(paginated);

            return new BasePaginatedList<ServiceAppointmentModelView>(serviceAppointmentModelViews, totalCount, pageNumber, pageSize);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error in GetAllServiceAppointment: {ex.Message}", ex);
        }
    }

    public async Task<string> DeleteServiceAppointment(string id)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new Exception("Please provide a valid Appointment ID.");
            }

            // get service appointment from database
            var serviceAppointment = await _unitOfWork.GetRepository<ServiceAppointment>().Entities
                    .FirstOrDefaultAsync(s => s.Id == id && !s.DeletedTime.HasValue)
                    ?? throw new Exception("The Service Appointment cannot be found or has been deleted!");

            // set deleteBy, deleteTime
            serviceAppointment.DeletedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
            serviceAppointment.DeletedTime = DateTimeOffset.UtcNow;

            //save
            await _unitOfWork.GetRepository<ServiceAppointment>().UpdateAsync(serviceAppointment);
            await _unitOfWork.SaveAsync();
            return "Deleted successfully";
        }
        catch (Exception ex)
        {
            throw new Exception($"Error in DeleteServiceAppointment: {ex.Message}", ex);
        }
    }

    public async Task<string> EditServiceAppointment(EditServiceAppointmentModelView model)
    {
        try
        {
            if (model.Id.IsNullOrEmpty() && model.ServiceId.IsNullOrEmpty())
            {
                throw new Exception("Id, AppointmentId, or ServiceId null");
            }

            // get service appointment from database
            var serviceAppointment = await _unitOfWork.GetRepository<ServiceAppointment>()
                .Entities.FirstOrDefaultAsync(s => s.Id == model.Id && !s.DeletedTime.HasValue)
                ?? throw new Exception("The Service Appointment cannot be found or has been deleted!");

            // map new data
            serviceAppointment.ServiceId = model.ServiceId != serviceAppointment.ServiceId
                ? model.ServiceId
                : serviceAppointment.ServiceId;
            serviceAppointment.Rate = model.Rate != serviceAppointment.Rate
                ? model.Rate
                : serviceAppointment.Rate;
            serviceAppointment.Description = model.Description != serviceAppointment.Description
                ? model.Description
                : serviceAppointment.Description;
            serviceAppointment.Comment = model.Comment != serviceAppointment.Comment
                ? model.Comment
                : serviceAppointment.Comment;

            // set LastUpdatedTime, LastUpdatedBy
            serviceAppointment.LastUpdatedTime = DateTimeOffset.UtcNow;
            serviceAppointment.LastUpdatedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;

            // save
            await _unitOfWork.GetRepository<ServiceAppointment>().UpdateAsync(serviceAppointment);
            await _unitOfWork.SaveAsync();
            return "Edit successfully";
        }
        catch (Exception ex)
        {
            throw new Exception($"Error in EditServiceAppointment: {ex.Message}", ex);
        }
    }

    public async Task<string> CreateServiceAppointment(CreatServiceAppointmentModelView creatServiceAppointmentModelView)
    {
        try
        {
            if (creatServiceAppointmentModelView.AppointmentId.IsNullOrEmpty() &&
                creatServiceAppointmentModelView.ServiceId.IsNullOrEmpty())
            {
                throw new Exception("AppointmentId or ServiceId null");
            }

            var service = _unitOfWork.GetRepository<Contract.Repositories.Entity.Service>()
                .GetById(creatServiceAppointmentModelView.ServiceId);

            var appointment = _unitOfWork.GetRepository<Appointment>()
                .GetById(creatServiceAppointmentModelView.AppointmentId);

            if (service == null)
            {
                throw new KeyNotFoundException($"Service not found with {creatServiceAppointmentModelView.ServiceId}");
            }

            if (appointment == null)
            {
                throw new KeyNotFoundException($"Appointment not found with {creatServiceAppointmentModelView.AppointmentId}");
            }

            ServiceAppointment serviceAppointment = new ServiceAppointment()
            {
                ServiceId = creatServiceAppointmentModelView.ServiceId,
                AppointmentId = creatServiceAppointmentModelView.AppointmentId,
                Appointment = appointment,
                Service = service,
                CreatedTime = DateTimeOffset.UtcNow,
                CreatedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value,
                Description = creatServiceAppointmentModelView.Description
            };
            await _unitOfWork.GetRepository<ServiceAppointment>().InsertAsync(serviceAppointment);
            await _unitOfWork.SaveAsync();
            return "Created successfully";
        }
        catch (Exception ex)
        {
            throw new Exception($"Error in CreateServiceAppointment: {ex.Message}", ex);
        }
    }

}
