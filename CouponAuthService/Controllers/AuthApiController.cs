using CouponAuthService.Model.DTO;
using CouponAuthService.Services.IService;
using Microsoft.AspNetCore.Mvc;

namespace CouponAuthService.Controllers
{
	[Route("api/auth")]
	[ApiController]
	public class AuthApiController : ControllerBase
	{

		private readonly IAuthService _authService;
		protected ResponseDto _responseDto;

        public AuthApiController(IAuthService authService)
        {
			_authService = authService;
			_responseDto = new();

		}
        [HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] RegistrationRequestDto model)
		{
			var errormesage=await _authService.Register(model);
			if (!string.IsNullOrEmpty(errormesage)) 
			{
				_responseDto.Success = false;
				_responseDto.Message= errormesage;
				return BadRequest(_responseDto);
			}
			return Ok(_responseDto);
		}

		[HttpPost("login")]
		public async Task<IActionResult> LogIn([FromBody] LoginRequestDto model)
		{
			var response=await _authService.Login(model);
			if (response.User == null) 
			{ 
				_responseDto.Success = false;
				_responseDto.Message= "Password is incorrect";
				return BadRequest(_responseDto);
			}
			_responseDto.Result = response;
			return Ok(_responseDto);
		}
	}
}
