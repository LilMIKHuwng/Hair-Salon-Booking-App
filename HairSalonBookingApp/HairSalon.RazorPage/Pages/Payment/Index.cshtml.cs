using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.ModelViews.PaymentModelViews;
using HairSalon.ModelViews.RoleModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HairSalon.RazorPage.Pages.Payment
{
    public class PaymentManagementModel : PageModel
    {
        private readonly IPaymentService _paymentService;

        public PaymentManagementModel(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public BasePaginatedList<PaymentModelView> Payment { get; set; }


        public async Task<IActionResult> OnGetAsync(int pageNumber = 1, int pageSize = 5, string? id = null, string? appointmentId = null, string? paymentMethod = null)
        {
            var userRolesJson = HttpContext.Session.GetString("UserRoles");

            if (userRolesJson != null)
            {
                var userRoles = JsonConvert.DeserializeObject<List<string>>(userRolesJson);

                // Check if the user has "Admin" role
                if (userRoles.Contains("Admin"))
                {
                    // If the user is an Admin, retrieve all payments with filters
                    Payment = await _paymentService.GetAllPaymentAsync(pageNumber, pageSize, id, appointmentId, paymentMethod);
                    return Page();
                }

                // Check if the user has "User" role
                if (userRoles.Contains("User"))
                {
                    TempData["InfoMessage"] = "You have access to this page, but you are not allowed to view all payments.";
                    return Page(); // Show message on the same page
                }

                // If the user has neither Admin nor User role
                TempData["ErrorMessage"] = "You do not have permission to view this page.";
                return Page();
            }
            else
            {
                TempData["ErrorMessage"] = "You do not have permission to view this page.";
                return Page();
            }
        }
    }
}
