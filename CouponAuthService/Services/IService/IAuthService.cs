﻿using CouponAuthService.Model.DTO;

namespace CouponAuthService.Services.IService
{
	public interface IAuthService
	{
		Task<string> Register(RegistrationRequestDto registrationRequestDto);
		Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
		Task<bool> AssignRole(string email, string roleName);

	}
}
