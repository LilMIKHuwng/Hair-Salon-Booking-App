using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.PaymentModelViews;
using HairSalon.ModelViews.RoleModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HairSalon.RazorPage.Pages.Payment
{
    public class DetailModel : PageModel
    {
        private readonly IPaymentService _paymentService;

        public DetailModel(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        public PaymentModelView PaymentDetail { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            PaymentDetail = await _paymentService.GetPaymentByIdAsync(Id);
            if (PaymentDetail == null)
            {
                TempData["ErrorMessage"] = "Payment not found.";
                return RedirectToPage("/Payment/Index");
            }
            return Page();
        }
    }
}
