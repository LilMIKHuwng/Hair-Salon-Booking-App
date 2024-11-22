using System.Text.Json.Serialization;

namespace HairSalon.ModelViews.TokenModelViews
{
	public class TokenResponseModelView
	{
		[JsonPropertyName("access_token")]
		public string AccessToken { get; set; }

		[JsonPropertyName("refresh_token")]
		public string RefreshToken { get; set; } // Lưu ý, Google không trả refresh_token nếu không yêu cầu.

		[JsonPropertyName("token_type")]
		public string TokenType { get; set; }

		[JsonPropertyName("expires_in")]
		public int ExpiresIn { get; set; }

		[JsonPropertyName("id_token")]
		public string IdToken { get; set; } // Thêm trường này nếu bạn cần sử dụng id_token.

		[JsonPropertyName("scope")]
		public string Scope { get; set; } // Tùy chọn, có thể không cần.
	}
}
