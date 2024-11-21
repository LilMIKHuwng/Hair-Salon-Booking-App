using HairSalon.Contract.Services.Cache;
using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.RoleModelViews;
using HairSalon.Services.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HairSalonBE.API.Controllers
{
	public class SmsController : Controller
	{
		private readonly ISmsService _smsService;

		public SmsController(ISmsService smsService)
		{
			_smsService = smsService;
		}

		/// <summary>
		///     Gửi thông báo lịch hẹn qua SMS
		/// </summary>
		[HttpPost("send-sms")]
		public async Task<ActionResult<string>> SendSMSAsync(string PhoneNumber)
		{
			string result = await _smsService.SendSMSAsync(PhoneNumber);

			return Ok(new { Message = result });
		}
	}
}
