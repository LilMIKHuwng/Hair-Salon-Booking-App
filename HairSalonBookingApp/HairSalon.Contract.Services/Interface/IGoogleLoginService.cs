using HairSalon.ModelViews.TokenModelViews;

namespace HairSalon.Contract.Services.Interface
{
	public interface IGoogleLoginService
	{
		Task<string> GetGoogleLoginUrl();
		Task<TokenModelView> GetTokenFromCode(string code);
	}
}
