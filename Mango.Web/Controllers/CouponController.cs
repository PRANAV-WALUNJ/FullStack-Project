using Mango.Web.Models;
using Mango.Web.Services.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Mango.Web.Controllers
{
	public class CouponController : Controller
    {
        private readonly ICouponService _couponService;
        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
            
        }
        public async Task<IActionResult> CoponIndex()
        {
            List<CouponDto> list = new ();
            ResponseDto response = await _couponService.GetAllCouponAsync();
            if (response != null) 
            {
                list= JsonConvert.DeserializeObject<List<CouponDto>>(Convert.ToString(response.Result));    
            }
            return View(list);
        }

		public async Task<IActionResult> CouponCreate()
		{
			return View();
		}

        [HttpPost]
		public async Task<IActionResult> CouponCreate(CouponDto couponDto)
		{
            if (ModelState.IsValid)
            {
                ResponseDto response = await _couponService.CreateCouponAsync(couponDto);
                if (response != null)
                {
                    return RedirectToAction(nameof(CoponIndex));
                }
                else { return RedirectToAction(nameof(CoponIndex)); }
            }
			return View(couponDto);
		}

        public async Task<IActionResult> CouponDelete(int couponId)
        {
			ResponseDto response = await _couponService.GetCouponByIdAsync(couponId);
			if (response != null)
			{
			CouponDto? model = JsonConvert.DeserializeObject<CouponDto>(Convert.ToString(response.Result));
                return View(model);
			}
			return NotFound();
        }

        [HttpPost]
		public async Task<IActionResult> CouponDelete(CouponDto couponDto)
		{
			ResponseDto response = await _couponService.DeleteCouponAsync(couponDto.CounponId);
			if (response != null)
			{
				return RedirectToAction(nameof(CoponIndex));
			}
			return View(couponDto); ;
		}
	}
}
