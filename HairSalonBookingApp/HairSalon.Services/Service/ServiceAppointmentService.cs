using AutoMapper;
using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Repositories.Interface;
using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.ServiceAppointmentModelViews;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace HairSalon.Services.Service;

public class ServiceAppointmentService : IServiceAppointment
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;


    public ServiceAppointmentService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }


    /**
     * GetAllServiceAppointment from database Existing
     */
    public async Task<IList<ServiceAppointmentModelView>> GetAllServiceAppointment()
    {
        // access ServiceAppointment => Filter out appointments that have not been deleted
        IQueryable<ServiceAppointment> serviceAppointments =
            _unitOfWork.GetRepository<ServiceAppointment>()
                .Entities.Where(entity => !entity.DeletedTime.HasValue)
                .OrderByDescending(o => o.CreatedTime);

        // Get List Service Appointments from database 
        IList<ServiceAppointment> appointments = await serviceAppointments.ToListAsync();

        // maping List Service Appointments => List Service Appointments Model view 
        return _mapper.Map<List<ServiceAppointmentModelView>>(appointments);
    }


    public async Task<IList<ServiceAppointmentModelView>> GetAllServiceAppointmentByServiceEntity(
        Contract.Repositories.Entity.Service service)
    {
        // check service entity exists
        if (service.DeletedTime.HasValue)
        {
            throw new Exception();
        }

        IQueryable<ServiceAppointment> serviceAppointments = _unitOfWork.GetRepository<ServiceAppointment>()
            .Entities.Where(entity => entity.Service == service)
            .OrderByDescending(entity => entity.CreatedTime);

        IList<ServiceAppointment> appointments = await serviceAppointments.ToListAsync();
        return _mapper.Map<List<ServiceAppointmentModelView>>(appointments);
    }

    public async Task<IList<ServiceAppointmentModelView>> GetAllServiceAppointmentByAppointmentEntity
        (Appointment appointment)
    {
        if (appointment.DeletedTime.HasValue)
        {
            throw new Exception();
        }

        IQueryable<ServiceAppointment> serviceAppointments = _unitOfWork.GetRepository<ServiceAppointment>()
            .Entities.Where(entity => entity.Appointment == appointment)
            .OrderByDescending(entity => entity.CreatedTime);
        IList<ServiceAppointment> appointments = await serviceAppointments.ToListAsync();
        return _mapper.Map<List<ServiceAppointmentModelView>>(appointments);
    }


    public async Task<Boolean> DeleteServiceAppointment(string id)
    {
        ServiceAppointment? serviceAppointment = await _unitOfWork.GetRepository<ServiceAppointment>()
            .GetByIdAsync(id);

        if (serviceAppointment == null)
        {
            throw new NotImplementedException();
        }

        await _unitOfWork.GetRepository<ServiceAppointment>().DeleteAsync(serviceAppointment);
        return true;
    }


    public async Task<List<ServiceAppointmentModelView>> GetAllServiceAppointmentByUserEntity(User user)
    {
        if (user.DeletedTime.HasValue)
        {
            throw new Exception();
        }

        IQueryable<ServiceAppointment> serviceAppointments = _unitOfWork.GetRepository<ServiceAppointment>()
            .Entities.Where(entity => entity.Appointment.User == user)
            .OrderByDescending(entity => !entity.DeletedTime.HasValue)
            .ThenByDescending(entity => entity.CreatedTime);

        IList<ServiceAppointment> appointments = await serviceAppointments.ToListAsync();

        return _mapper.Map<List<ServiceAppointmentModelView>>(appointments);
    }

    public Task<bool> EditServiceAppointment()
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceAppointment> CreateServiceAppointment(
        ServiceAppointmentModelView serviceAppointmentModelView)
    {
        if (serviceAppointmentModelView == null)
        {
            throw new ArgumentNullException(nameof(serviceAppointmentModelView));
        }

        if (serviceAppointmentModelView.AppointmentId.IsNullOrEmpty() &&
            serviceAppointmentModelView.ServiceId.IsNullOrEmpty())
        {
            throw new Exception("AppointmentId or ServiceId null");
        }

        Contract.Repositories.Entity.Service? service = _unitOfWork
            .GetRepository<Contract.Repositories.Entity.Service>()
            .GetById(serviceAppointmentModelView.ServiceId);

        Appointment? appointment =
            _unitOfWork.GetRepository<Appointment>().GetById(serviceAppointmentModelView.AppointmentId);

        if (service == null)
        {
            throw new KeyNotFoundException($"Service not found with {serviceAppointmentModelView.ServiceId}");
        }

        if (appointment == null)
        {
            throw new KeyNotFoundException($"Service not found with {serviceAppointmentModelView.AppointmentId}");
        }

        ServiceAppointment serviceAppointment = new ServiceAppointment()
        {
            ServiceId = serviceAppointmentModelView.ServiceId,
            AppointmentId = serviceAppointmentModelView.AppointmentId,
            Appointment = appointment,
            Service = service,
            CreatedTime = serviceAppointmentModelView.CreatedTime,
            CreatedBy = serviceAppointmentModelView.CreatedBy
        };
        await _unitOfWork.GetRepository<ServiceAppointment>().InsertAsync(serviceAppointment);
        await _unitOfWork.GetRepository<ServiceAppointment>().SaveAsync();
        return _mapper.Map<ServiceAppointment>(serviceAppointment);
    }

    public async Task<ServiceAppointmentModelView> GetServiceAppointmentById(string id)
    {
        if (id.IsNullOrEmpty())
        {
            throw new KeyNotFoundException("id null:");
        }

        ServiceAppointment? serviceAppointment = _unitOfWork.GetRepository<ServiceAppointment>().GetById(id);
        if (serviceAppointment == null)
        {
            throw new Exception("ServiceAppointment not found: " + id);
        }

        if (!serviceAppointment.DeletedTime.HasValue)
        {
            throw new Exception("ServiceAppointment not Exist: " + id);
        }

        return new ServiceAppointmentModelView(serviceAppointment);
    }
}