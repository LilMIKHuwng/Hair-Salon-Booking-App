using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using Newtonsoft.Json;
using HairSalon.ModelViews.AppointmentModelViews;

namespace HairSalon.RazorPage.Pages.Appointment
{
	public class AppointmentManagementModel : PageModel
	{
		private readonly IAppointmentService _appointmentService;

		public AppointmentManagementModel(IAppointmentService appointmentService)
		{
			_appointmentService = appointmentService;
		}

		public BasePaginatedList<AppointmentModelView> Appointments { get; set; }


		public async Task<IActionResult> OnGetAsync(int pageNumber = 1, int pageSize = 5, DateTime? startDate = null, DateTime? endDate = null,
			string? id = null, Guid? userId = null, Guid? stylistId = null, string? statusForAppointment = null)
		{
			var userRolesJson = HttpContext.Session.GetString("UserRoles");

			if (userRolesJson != null)
			{
				var userRoles = JsonConvert.DeserializeObject<List<string>>(userRolesJson);

				// Check if the user has "Admin" or "Manager" roles
				if (!userRoles.Any(role => role == "Admin" || role == "Manager" || role == "User" || role == "Stylist"))
				{
					TempData["ErrorMessage"] = "You do not have permission to view this page.";
					return Page(); // Show error message on the same page
				}

				if (userRoles.Any(roles => roles == "User"))
				{
					userId = Guid.Parse(HttpContext.Session.GetString("UserId"));
				}

				if (userRoles.Any(roles => roles == "Stylist"))
				{
					stylistId = Guid.Parse(HttpContext.Session.GetString("UserId"));
				}
			}
			else
			{
				TempData["ErrorMessage"] = "You do not have permission to view this page.";
				return Page();
			}

			// If authorized, retrieve appointment data
			Appointments = await _appointmentService.GetAllAppointmentAsync(pageNumber, pageSize, startDate, endDate, id, userId, stylistId, statusForAppointment);
			return Page();
		}

		public async Task<IActionResult> OnPostAsync(string id, string action)
		{
			if (string.IsNullOrEmpty(id))
			{
				TempData["ErrorMessage"] = "Appointment ID is required.";
				return RedirectToPage();
			}

			//Save roleId to tempdata
			TempData["AppointmentId"] = id;

			switch (action?.ToLower())
			{
				case "update":
					return RedirectToPage("/Appointment/Update");
				case "detail":
					return RedirectToPage("/Appointment/Detail");
				case "delete":
					return RedirectToPage("/Appointment/Delete");
				case "completed":
					return RedirectToPage("/Appointment/MarkCompleted");
				case "confirm":
					return RedirectToPage("/Appointment/MarkConfirmed");
				default:
					TempData["ErrorMessage"] = "Invalid action.";
					return RedirectToPage();
			}
		}

	}
}
