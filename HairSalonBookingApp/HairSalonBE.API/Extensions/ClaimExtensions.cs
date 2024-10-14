using System.Security.Claims;

namespace HairSalonBE.API.Extensions
{
    public static class ClaimExtensions
    {
        public static string GetUsername(this ClaimsPrincipal user)
        {
            // Tìm giá trị của claim với loại là "nameidentifier" (username trong JWT)
            return user.FindFirstValue(ClaimTypes.Name) ??
                  user.FindFirstValue("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
        }
    }
}
