using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.PaymentModelViews;
using HairSalon.ModelViews.ShopModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HairSalon.RazorPage.Pages.Payment
{
    public class DeleteModel : PageModel
    {
        private readonly IPaymentService _paymentService;

        public DeleteModel(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        public PaymentModelView Payment { get; set; }

        // Property to store error messages
        [TempData]
        public string ErrorMessage { get; set; }

        // Property to store response or success messages
        [TempData]
        public string ResponseMessage { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Payment = await _paymentService.GetPaymentByIdAsync(Id);
            if (Payment == null)
            {
                ErrorMessage = "Payment Not Found";
                return Redirect("/Payment/Index"); // Redirect if Payment is not found
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            string response = await _paymentService.DeletePaymentpAsync(Id);
            if (response == "Payment deleted successfully.")
            {
                ResponseMessage = response;
                return Redirect("/Payment/Index");
            }
            // Set ErrorMessage if deletion fails
            ErrorMessage = response;
            return Page();
        }
    }
}
