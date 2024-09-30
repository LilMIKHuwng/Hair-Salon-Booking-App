using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.ModelViews.ServiceAppointmentModelViews;
using Microsoft.AspNetCore.Mvc;

namespace HairSalonBE.API.Controllers;

[Route("api/[controller]/service_appoiment")]
[ApiController]
public class ServiceAppointmentController : ControllerBase
{
    private readonly IServiceAppointment _serviceAppointment;

    public ServiceAppointmentController(IServiceAppointment serviceAppointment)
    {
        _serviceAppointment = serviceAppointment;
    }


    /*
     * get all services appointment exits in database
     */
    [HttpGet]
    public async Task<ActionResult<BasePaginatedList<ServiceAppointmentModelView>>> GetAllServicesAppointments()
    {
        try
        {
            var result = await _serviceAppointment.GetAllServiceAppointment();
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(new { Message = e.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceAppointmentModelView>>
        GetAllServicesAppointmentsById(string id)
    {
        try
        {
            var result = await _serviceAppointment.GetServiceAppointmentById(id);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(new { Message = e.Message });
        }
    }

    [HttpPost]
    public async Task<ActionResult<ServiceAppointment>> CreateServiceAppointment(
        CreatServiceAppointmentModelView creatServiceAppointmentModelView)
    {
        try
        {
            var result = await _serviceAppointment.CreateServiceAppointment(creatServiceAppointmentModelView);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(new { Message = e.Message });
        }
    }

    [HttpPut]
    public async Task<ActionResult<Boolean>> UpdateServiceAppointment(
        [FromQuery] EditServiceAppointmentModelView editServiceAppointmentModelView)
    {
        try
        {
            var result = await _serviceAppointment.EditServiceAppointment(editServiceAppointmentModelView);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(new { Message = e.Message });
        }
    }

    [HttpGet("/services/{service}")]
    public async Task<ActionResult<BasePaginatedList<ServiceAppointmentModelView>>>
        GetAllServiceAppointmentByServiceEntity(string service)
    {
        try
        {
            var result = await _serviceAppointment.GetAllServiceAppointmentByServiceId(service);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(new { Message = e.Message });
        }
    }


    [HttpGet("/appointments/{id}")]
    public async Task<ActionResult<BasePaginatedList<ServiceAppointmentModelView>>>
        GetServiceAppointmentByAppointmentId(string id)
    {
        try
        {
            var result = await _serviceAppointment.GetAllServiceAppointmentByAppointmentID(id);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(new { Message = e.Message });
        }
    }

    [HttpGet("/userid/{id}")]
    public async Task<ActionResult<BasePaginatedList<ServiceAppointmentModelView>>>
        GetServiceAppointmentByUserId(string id)
    {
        try
        {
            var result = await _serviceAppointment.GetAllServiceAppointmentByUserId(id);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(new { Message = e.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Boolean>> DeleteServiceAppointment(
        DeleteServiceAppointmentModelView deleteServiceAppointmentModelView)
    {
        try
        {
            var result = await _serviceAppointment.DeleteServiceAppointment(deleteServiceAppointmentModelView);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(new { e.Message });
        }
    }
}