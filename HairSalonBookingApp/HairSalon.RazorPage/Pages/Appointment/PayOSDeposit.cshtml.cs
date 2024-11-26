using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.VnPayModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HairSalon.RazorPage.Pages.Appointment;

public class PayOSDepositModel : PageModel
{
    private readonly IPayOSService _payOSService;
    private readonly IAppointmentService _appointmentService;

    public PayOSDepositModel(IPayOSService payOSService, IAppointmentService appointmentService)
    {
        _payOSService = payOSService;
        _appointmentService = appointmentService;
    }

    [BindProperty(SupportsGet = true)]
    public string AppointmentId { get; set; }

    public double Amount { get; private set; }
    public string Information { get; private set; }

    public string Type { get; private set; }
    public string? ErrorMessage { get; set; }

    public async Task<IActionResult> OnGetAsync(string appointmentId)
    {
        AppointmentId = appointmentId;

        var appointment = await _appointmentService.GetAppointmentByIdAsync(AppointmentId);
        if (appointment == null)
        {
            ErrorMessage = "Appointment not found.";
            return Page();
        }

        // Set readonly fields
        Amount = (double)(appointment.TotalAmount * 10 / 100); // 10% deposit
        Information = $"Deposit for Appointment #{AppointmentId}";
        Type = "PayOS";

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            ErrorMessage = "Invalid input. Please try again.";
            return Page();
        }

		HttpContext.Session.SetString("AppointmentId", AppointmentId);

		var appointment = await _appointmentService.GetAppointmentByIdAsync(AppointmentId);
        if (appointment == null)
        {
            ErrorMessage = "Appointment not found.";
            return Page();
        }

        var paymentRequest = new PaymentRequestModelView
        {
            Amount = (double)(appointment.TotalAmount * 10 / 100),
            Information = $"Deposit for Appointment #{AppointmentId}",
            Type = "PayOS"
        };

        try
        {
            var paymentLink = await _payOSService.CreatePaymentLink(paymentRequest);

            if (string.IsNullOrEmpty(paymentLink))
            {
                ErrorMessage = "Failed to generate the payment link. Please try again.";
                return Page();
            }

            // Redirect to the payment link
            return Redirect(paymentLink);
        }
        catch (Exception ex)
        {
            ErrorMessage = $"An error occurred: {ex.Message}";
            return Page();
        }
    }
}
