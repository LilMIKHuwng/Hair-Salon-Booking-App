using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.AppointmentModelViews;
using HairSalon.ModelViews.VnPayModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HairSalon.RazorPage.Pages.Payment
{
    public class CreateModel : PageModel
    {
        private readonly IVnPayService _paymentService;
        private readonly IAppointmentService _appointmentService;

        public CreateModel(IVnPayService paymentService, IAppointmentService appointmentService)
        {
            _paymentService = paymentService;
            _appointmentService = appointmentService;
        }

        [BindProperty]
        public PaymentResponseModelView NewPayment { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        [TempData]
        public string ResponseMessage { get; set; }

        [TempData]
        public string DeniedMessage { get; set; }

        public List<AppointmentModelView> ConfirmedAppointments { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            // Retrieve user roles from session
            var userRolesJson = HttpContext.Session.GetString("UserRoles");
            if (userRolesJson == null)
            {
                TempData["DeniedMessage"] = "You do not have permission";
                return RedirectToPage("/Error");
            }

            var userRoles = JsonConvert.DeserializeObject<List<string>>(userRolesJson);

            // Check if the user has the "Admin" role
            if (!userRoles.Any(role => role == "Admin"))
            {
                TempData["DeniedMessage"] = "You do not have permission";
                return Page();
            }

            // Retrieve all appointments
            var allAppointments = await _appointmentService.GetAppointmentsForDropdownAsync() ?? new List<AppointmentModelView>();

            // Filter appointments to include only those that are confirmed
            ConfirmedAppointments = allAppointments.Where(a => a.StatusForAppointment == "Completed").ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var userId = HttpContext.Session.GetString("UserId");
                string response = await _paymentService.ExecutePayment(NewPayment, userId);

                if (response == "Payment added successfully.")
                {
                    // Call MarkSuccessfull from the injected service
                    var appointmentResponse = await _appointmentService.MarkSuccessfull(NewPayment.AppointmentId, userId);
                    if (appointmentResponse != "success")
                    {
                        // Handle appointment status update failure
                        TempData["ErrorMessage"] = appointmentResponse;
                        return Page();
                    }

                    ResponseMessage = response;
                    return RedirectToPage("/Payment/Index"); // Redirect to the payment list page
                }

                // Set ErrorMessage if there’s an error in payment processing
                TempData["ErrorMessage"] = response;
            }
            return Page(); // Return the same page in case of validation errors or issues
        }
    }

}
