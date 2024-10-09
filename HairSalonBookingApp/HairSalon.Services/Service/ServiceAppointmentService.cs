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

	public async Task<BasePaginatedList<ServiceAppointmentModelView>> GetAllServiceAppointment(int pageNumber, int pageSize, string? id, string? serviceId, string? appointmentId)
	{
		//get service appointment from database 
		IQueryable<ServiceAppointment> serviceAppointmentQuery = _unitOfWork.GetRepository<ServiceAppointment>().Entities
			.Where(p => !p.DeletedTime.HasValue)
			.OrderByDescending(s => s.CreatedTime);

		if (!string.IsNullOrEmpty(id))
		{
			serviceAppointmentQuery = serviceAppointmentQuery.Where(a => a.Id.Equals(id));
		}

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

		//pagination
		List<ServiceAppointment> paginated = await serviceAppointmentQuery
			.Skip((pageNumber - 1) * pageSize)
			.Take(pageSize)
			.ToListAsync();

		//map data entity to model
		List<ServiceAppointmentModelView> serviceAppointmentModelViews = _mapper.Map<List<ServiceAppointmentModelView>>(paginated);

		return new BasePaginatedList<ServiceAppointmentModelView>(serviceAppointmentModelViews, totalCount, pageNumber, pageSize);
	}

	public async Task<string> DeleteServiceAppointment(string id)
	{
		if (string.IsNullOrWhiteSpace(id))
		{
			return "Please provide a valid Service Appointment ID.";
		}

		// get service appointment from database
		var serviceAppointment = await _unitOfWork.GetRepository<ServiceAppointment>().Entities
				.FirstOrDefaultAsync(s => s.Id == id && !s.DeletedTime.HasValue);

		if (serviceAppointment == null)
		{
			return "The Service Appointment cannot be found or has been deleted!";
		}

		// set deleteBy, deleteTime
		serviceAppointment.DeletedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
		serviceAppointment.DeletedTime = DateTimeOffset.UtcNow;

		//save
		await _unitOfWork.GetRepository<ServiceAppointment>().UpdateAsync(serviceAppointment);
		await _unitOfWork.SaveAsync();
		return "Deleted Service Appointment successfully";
	}

	public async Task<string> EditServiceAppointment(string id, EditServiceAppointmentModelView model)
	{
		if (id.IsNullOrEmpty())
		{
			return "Please provide a valid Service Appointment ID.";
		}

		// get service appointment from database
		var serviceAppointment = await _unitOfWork.GetRepository<ServiceAppointment>()
			.Entities.FirstOrDefaultAsync(s => s.Id == id && !s.DeletedTime.HasValue);

		if (serviceAppointment == null)
		{
			return "The Service Appointment cannot be found or has been deleted!";
		}

		// map new data, only if not null or different
		if (!string.IsNullOrEmpty(model.AppointmentId) && model.AppointmentId != serviceAppointment.AppointmentId)
		{
			serviceAppointment.AppointmentId = model.AppointmentId;
		}

		if (!string.IsNullOrEmpty(model.ServiceId) && model.ServiceId != serviceAppointment.ServiceId)
		{
			serviceAppointment.ServiceId = model.ServiceId;
		}

		if (model.Rate.HasValue && model.Rate != serviceAppointment.Rate)
		{
			serviceAppointment.Rate = model.Rate.Value;
		}

		if (!string.IsNullOrEmpty(model.Description) && model.Description != serviceAppointment.Description)
		{
			serviceAppointment.Description = model.Description;
		}

		if (!string.IsNullOrEmpty(model.Comment) && model.Comment != serviceAppointment.Comment)
		{
			serviceAppointment.Comment = model.Comment;
		}

		// set LastUpdatedTime, LastUpdatedBy
		serviceAppointment.LastUpdatedTime = DateTimeOffset.UtcNow;
		serviceAppointment.LastUpdatedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;

		// save
		await _unitOfWork.GetRepository<ServiceAppointment>().UpdateAsync(serviceAppointment);
		await _unitOfWork.SaveAsync();
		return "Edit Service Appointment successfully";
	}

	public async Task<string> CreateServiceAppointment(CreatServiceAppointmentModelView creatServiceAppointmentModelView)
	{
		ServiceAppointment newRole = _mapper.Map<ServiceAppointment>(creatServiceAppointmentModelView);
		newRole.CreatedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
		newRole.CreatedTime = DateTimeOffset.UtcNow;

		await _unitOfWork.GetRepository<ServiceAppointment>().InsertAsync(newRole);
		await _unitOfWork.SaveAsync();
		return "Created Service Appointment successfully";
	}
}
