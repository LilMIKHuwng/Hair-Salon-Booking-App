using System.Text;
using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Repositories.Interface;
using HairSalon.Contract.Services.Interface;
using HairSalon.Repositories.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HairSalon.Services.Service
{
	public class SmsService : ISmsService
	{
		private readonly IConfiguration _configuration;
		private readonly IUnitOfWork _unitOfWork;

		public SmsService(IConfiguration configuration, IUnitOfWork unitOfWork)
		{
			_configuration = configuration;
			_unitOfWork = unitOfWork;
		}

		public async Task<string> SendSMSAsync(string phoneNumber)
		{
			if (string.IsNullOrWhiteSpace(phoneNumber))
			{
				return "Phone Number cannot be empty.";
			}

			var user = await GetUserByPhoneNumber(phoneNumber);
			if (user == null)
			{
				return "User with this phone number does not exist.";
			}

			var appointment = await GetUpcomingAppointment(user.Id);
			if (appointment == null)
			{
				return "No upcoming appointment or SMS already sent.";
			}

			if (!IsAppointmentForTomorrow(appointment.AppointmentDate))
			{
				return "The appointment date is not for tomorrow.";
			}

			return await SendSmsToUser(phoneNumber);
		}

		private async Task<ApplicationUsers> GetUserByPhoneNumber(string phoneNumber)
		{
			return await _unitOfWork.GetRepository<ApplicationUsers>()
									.Entities
									.Where(u => u.PhoneNumber == phoneNumber)
									.AsNoTracking()
									.FirstOrDefaultAsync();
		}

		private async Task<Appointment> GetUpcomingAppointment(Guid userId)
		{
			return await _unitOfWork.GetRepository<Appointment>()
									.Entities
									.Where(am => am.UserId.Equals(userId) && am.PhoneSent == false)
									.AsNoTracking()
									.FirstOrDefaultAsync();
		}

		private bool IsAppointmentForTomorrow(DateTime appointmentDate)
		{
			return appointmentDate.Date == DateTime.Today.AddDays(1).Date;
		}

		private async Task<string> SendSmsToUser(string phoneNumber)
		{
			string apiKey = _configuration["Esms:ApiKey"];
			string secretKey = _configuration["Esms:SecretKey"];
			string content = "Your appointment is scheduled for tomorrow. Please remember to be on time!";
			string smsType = "4"; // Type of SMS (appointment reminder)

			if (string.IsNullOrEmpty(apiKey) || string.IsNullOrEmpty(secretKey))
			{
				return "ApiKey or SecretKey are not configured.";
			}

			var jsonData = CreateSmsRequestJson(apiKey, secretKey, content, phoneNumber, smsType);

			try
			{
				var response = await SendSmsApiRequest(jsonData);
				if (response.IsSuccessStatusCode)
				{
					await MarkAppointmentAsSent(phoneNumber);
					return "SMS sent successfully.";
				}
				else
				{
					return $"Failed to send SMS. Status code: {response.StatusCode}";
				}
			}
			catch (Exception ex)
			{
				return $"Error: {ex.Message}";
			}
		}

		private string CreateSmsRequestJson(string apiKey, string secretKey, string content, string phoneNumber, string smsType)
		{
			return $@"
				{{
					""ApiKey"": ""{apiKey}"",
					""Content"": ""{content}"",
					""Phone"": ""{phoneNumber}"",
					""SecretKey"": ""{secretKey}"",
					""SmsType"": ""{smsType}""
				}}";
		}

		private async Task<HttpResponseMessage> SendSmsApiRequest(string jsonData)
		{
			using var client = new HttpClient();
			var request = new HttpRequestMessage(HttpMethod.Post, _configuration["Esms:Url"]);
			request.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			return await client.SendAsync(request);
		}

		private async Task MarkAppointmentAsSent(string phoneNumber)
		{
			var user = await GetUserByPhoneNumber(phoneNumber);
			var appointment = await GetUpcomingAppointment(user.Id);

			if (appointment != null)
			{
				appointment.PhoneSent = true;
				await _unitOfWork.SaveAsync();
			}
		}
	}
}
