﻿namespace CouponAuthService.Model.DTO
{
	public class ResponseDto
	{
		public object? Result { get; set; }
		public bool? Success { get; set; } = true;
		public string Message { get; set; } = "Data fetch succesfully";
	}
}