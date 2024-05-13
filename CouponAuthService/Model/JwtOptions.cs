namespace CouponAuthService.Model
{
	public class JwtOptions
	{
		public string Issuer { get; set; } = string.Empty;
		public string Audience { get; set; } = string.Empty;
		public string Secret { get; set; } = "8c6d7e2d-5f1b-4d9e-a715-2a01f2f7e3c8";
	}
}
