using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.ModelViews.PaymentModelViews;
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

        public bool IsAdmin { get; set; }

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
                    IsAdmin = true;
                    // If the user is an Admin, retrieve all payments with filters
                    Payment = await _paymentService.GetAllPaymentAsync(pageNumber, pageSize, id, appointmentId, paymentMethod);
                    return Page();
                }
                var userID = HttpContext.Session.GetString("UserId");
                // Check if the user has "User" role
                if (userRoles.Contains("User"))
                {
                    IsAdmin = false;
                    Payment = await _paymentService.GetAllPaymentByUserIdAsync(userID, pageNumber, pageSize);
                    return Page(); // Show message on the same page
                }
            }

            // If the user has neither Admin nor User role
            TempData["ErrorMessage"] = "You do not have permission to view this page.";
            return RedirectToPage("/Error");
        }

        public async Task<IActionResult> OnPostAsync(string id, string action)
        {
            if (string.IsNullOrEmpty(id))
            {
                TempData["ErrorMessage"] = "Payment ID is required.";
                return RedirectToPage();
            }

            //Save roleId to tempdata
            TempData["PaymentId"] = id;

            switch (action?.ToLower())
            {
                case "detail":
                    return RedirectToPage("/Payment/Detail");
                case "delete":
                    return RedirectToPage("/Payment/Delete");
                default:
                    TempData["ErrorMessage"] = "Invalid action.";
                    return RedirectToPage();
            }
        }
    }
}
