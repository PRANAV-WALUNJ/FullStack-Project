﻿using Mango.Web.Models;
using Mango.Web.Services.IService;
using Mango.Web.Utility;

namespace Mango.Web.Services.Repository
{
	public class AuthService : IAuthService
	{
		private readonly IBaseService _baseService;
		public AuthService(IBaseService baseService)
		{
			_baseService = baseService;
		}

		public async Task<ResponseDto?> AssignRoleAsync(RegistrationRequestDto registrationRequestDto)
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				Apitype = StaticData.ApiType.POST,
				Data = registrationRequestDto,
				Url = StaticData.AuthAPIBase + "/api/auth/AssignRole"
			});
		}

		public async Task<ResponseDto?> LoginAsync(LoginRequestDto loginRequestDto)
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				Apitype = StaticData.ApiType.POST,
				Data = loginRequestDto,
				Url = StaticData.AuthAPIBase + "/api/auth/login"
			}/*, withBearer: false*/);
		}

		public async Task<ResponseDto?> RegisterAsync(RegistrationRequestDto registrationRequestDto)
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				Apitype = StaticData.ApiType.POST,
				Data = registrationRequestDto,
				Url = StaticData.AuthAPIBase + "/api/auth/register"
			}/*, withBearer: false*/);
		}
	}
}
