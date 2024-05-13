using Microsoft.AspNetCore.Identity;

namespace CouponAuthService.Model
{
	public class ApplicationUsers :IdentityUser
	{
		public string Name { get; set; }
	}
}
