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
            // Create the email message with recipient's email, subject, and body
            var message = new EmailMessage
            {
                To = email, // Set recipient's email address
                Subject = "Your OTP Code", // Subject of the email
                Body = $"Your OTP code is {confirmationCode}. It will expire in 10 minutes." // Email body containing the OTP code
            };

            // Call the method to send the email asynchronously
            await SendEmailAsync(message);
        }

        private async Task SendEmailAsync(EmailMessage message)
        {
            // Retrieve SMTP configuration settings from app settings
            var smtpConfig = _configuration.GetSection("Smtp");
            var smtpHost = smtpConfig["Host"];
            var smtpPort = int.Parse(smtpConfig["Port"]);
            var smtpEnableSsl = bool.Parse(smtpConfig["EnableSsl"]); 
            var smtpUsername = smtpConfig["Username"]; 
            var smtpPassword = smtpConfig["Password"];

            // Initialize the SMTP client with the configuration settings
            var smtpClient = new SmtpClient(smtpHost)
            {
                Port = smtpPort, 
                Credentials = new NetworkCredential(smtpUsername, smtpPassword),
                EnableSsl = smtpEnableSsl,
            };

            // Create a mail message to be sent via the SMTP client
            var mailMessage = new MailMessage
            {
                From = new MailAddress(smtpUsername), 
                Subject = message.Subject,
                Body = message.Body, 
                IsBodyHtml = false 
            };

            // Add the recipient's email address to the mail message
            mailMessage.To.Add(message.To);

            try
            {
                await smtpClient.SendMailAsync(mailMessage); // Send the email asynchronously
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error sending email", ex);
            }
        }
    }
}
