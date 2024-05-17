using CouponAuthService.Model.DTO;
using CouponAuthService.Services.IService;
using Microsoft.AspNetCore.Authentication;
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
		//public async Task<IActionResult> LogOut()
		//{
		//	await HttpContext.SignOutAsync();
		//	_tokenProvider.ClearToken();
		//	return RedirectToAction("Index","Home");
		//}
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


		[HttpPost("assignrole")]
		public async Task<IActionResult> AssignRole([FromBody] RegistrationRequestDto model)
		{
			var response = await _authService.AssignRole(model.Email,model.Role.ToUpper());
			if (!response)
			{
				_responseDto.Success = false;
				_responseDto.Message = "Error while assign role";
				return BadRequest(_responseDto);
			}
			
			return Ok(_responseDto);
		}
	}
}
