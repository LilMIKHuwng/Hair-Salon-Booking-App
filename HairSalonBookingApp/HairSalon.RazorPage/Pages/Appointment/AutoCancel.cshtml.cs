using HairSalon.Contract.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HairSalon.RazorPage.Pages.Appointment
{
	public class AutoCancelModel : PageModel
	{
		private readonly IAppointmentService _appointmentService;

		public AutoCancelModel(IAppointmentService appointmentService)
		{
			_appointmentService = appointmentService;
		}

		[BindProperty(SupportsGet = true)]
		public string? Id { get; set; }

		[BindProperty(SupportsGet = true)]
		public string? UserId { get; set; }

		public string? Message { get; set; }

		public async Task<IActionResult> OnGetAsync()
		{
			if (string.IsNullOrWhiteSpace(Id))
			{
				Message = "Invalid appointment ID.";
				return RedirectToPage("/Appointment/Index"); 
			}

			var result = await _appointmentService.MarkCancel(Id, UserId);

			if (result == "success")
			{
				Message = "Appointment successfully cancelled due to timeout.";
			}
			else
			{
				Message = result; 
			}

			return RedirectToPage("/Appointment/Index");
		}
	}
}
