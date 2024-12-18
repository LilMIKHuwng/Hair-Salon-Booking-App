namespace HairSalon.Contract.Services.Interface
{
    public interface IEmailService
    {
        Task SendEmailConfirmationCodeAsync(string email, string confirmationCode);

        Task SendEmailToConfirmDateAsync(); // New method for appointment reminders

        Task SendEmailExternalAsync(string email, string subject, string htmlMessage);
    }

}
