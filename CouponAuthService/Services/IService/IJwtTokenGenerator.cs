using CouponAuthService.Model;

namespace CouponAuthService.Services.IService
{

	public interface IJwtTokenGenerator
	{
		string GenerateToken(ApplicationUsers applicationUser, IEnumerable<string> roles);
	}
}
