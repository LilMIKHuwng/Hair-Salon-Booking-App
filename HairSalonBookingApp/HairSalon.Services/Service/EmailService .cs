using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.ApplicationUserModelViews;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace HairSalon.Services.Service
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailConfirmationCodeAsync(string email, string confirmationCode)
        {
            var message = new EmailMessage
            {
                To = email,
                Subject = "Your OTP Code",
                Body = $"Your OTP code is {confirmationCode}. It will expire in 10 minutes."
            };
            await SendEmailAsync(message);
        }

        private async Task SendEmailAsync(EmailMessage message)
        {
            var smtpConfig = _configuration.GetSection("Smtp");
            var smtpHost = smtpConfig["Host"];
            var smtpPort = int.Parse(smtpConfig["Port"]);
            var smtpEnableSsl = bool.Parse(smtpConfig["EnableSsl"]);
            var smtpUsername = smtpConfig["Username"];
            var smtpPassword = smtpConfig["Password"];

            var smtpClient = new SmtpClient(smtpHost)
            {
                Port = smtpPort,
                Credentials = new NetworkCredential(smtpUsername, smtpPassword),
                EnableSsl = smtpEnableSsl,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(smtpUsername),
                Subject = message.Subject,
                Body = message.Body,
                IsBodyHtml = false
            };

            mailMessage.To.Add(message.To);

            try
            {
                await smtpClient.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có lỗi khi gửi email
                throw new InvalidOperationException("Error sending email", ex);
            }
        }
    }
}
