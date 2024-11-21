using AutoMapper;
using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Repositories.Interface;
using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.ApplicationUserModelViews;
using HairSalon.Repositories.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace HairSalon.Services.Service
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork; // To access appointment data
        private readonly IMapper _mapper; // To map entities to DTOs

        public EmailService(IConfiguration configuration, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _configuration = configuration;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task SendEmailToConfirmDateAsync()
        {
            // Get the list of appointments to process
            var now = DateTime.Now;
            var appointments = await _unitOfWork.GetRepository<Appointment>().Entities
                .Where(a => !a.DeletedTime.HasValue && !a.EmailSent &&
                            a.AppointmentDate >= now && // Appointment is not in the past
                            a.AppointmentDate <= now.AddDays(1)) // Appointment is within 24 hours
                .ToListAsync();

            if (!appointments.Any())
            {
                Console.WriteLine("No appointments to send reminders for.");
                return;
            }

            foreach (var appointment in appointments)
            {
                var user = await _unitOfWork.GetRepository<ApplicationUsers>().GetByIdAsync(appointment.UserId);

                var email = user.Email; // Customer's email
                var appointmentDate = appointment.AppointmentDate;

                // Compose the reminder email
                var message = new EmailMessage
                {
                    To = email,
                    Subject = "Appointment Reminder",
                    Body = $"Dear {user.UserName},\n\n" +
                           $"This is a friendly reminder that you have an appointment scheduled on " +
                           $"{appointmentDate:dddd, MMMM d, yyyy} at {appointmentDate:hh:mm tt}.\n\n" +
                           $"Please contact us if you have any questions or need to reschedule.\n\n" +
                           $"Thank you!"
                };

                // Send the email
                await SendEmailAsync(message);

                // Mark the appointment as EmailSent
                appointment.EmailSent = true;
            }

            // Save changes to database
            await _unitOfWork.SaveAsync();

            Console.WriteLine($"Sent reminders for {appointments.Count} appointments.");
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
                throw new InvalidOperationException("Error sending email", ex);
            }
        }
    }

}
