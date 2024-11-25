namespace HairSalon.Contract.Services.Interface
{
	public interface ISmsService
	{
		Task<string> SendSMSAsync(string phoneNumber);
	}
}
