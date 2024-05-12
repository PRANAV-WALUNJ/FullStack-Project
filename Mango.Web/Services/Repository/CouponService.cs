using Mango.Web.Models;
using Mango.Web.Services.IService;

namespace Mango.Web.Services.Repository
{
    public class CouponService : ICouponService
    {
        private readonly IBaseService _baseService;
        public CouponService(IBaseService baseService)
        {
            _baseService = baseService;

        }
        public async Task<ResponseDto> CreateCouponAsync(CouponDto couponDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                Apitype = Utility.StaticData.ApiType.POST,
                Data=couponDto,
                Url = Utility.StaticData.CouponAPIBase + "/api/coupon/Create"
            });
        }

        public async Task<ResponseDto> DeleteCouponAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                Apitype = Utility.StaticData.ApiType.DELETE,
                Url = Utility.StaticData.CouponAPIBase + "/api/coupon/DeleteById?id=" + id
            });
        }

        public async Task<ResponseDto> GetAllCouponAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                Apitype = Utility.StaticData.ApiType.GET,
                Url = Utility.StaticData.CouponAPIBase + "/api/coupon/GetAll"
            });
        }

        public async Task<ResponseDto> GetCouponByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                Apitype = Utility.StaticData.ApiType.GET,
                Url = Utility.StaticData.CouponAPIBase + "/api/coupon/GetById?id=" + id
            });
        }

        public async Task<ResponseDto> GetCouponCodeAsync(string couponCode)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                Apitype = Utility.StaticData.ApiType.GET,
                Url = Utility.StaticData.CouponAPIBase + "/api/coupon/GetById/Code" + couponCode
            });
        }

        public async Task<ResponseDto> UpdateCouponAsync(CouponDto couponDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                Apitype = Utility.StaticData.ApiType.PUT,
                Data = couponDto,
                Url = Utility.StaticData.CouponAPIBase + "/api/coupon/Update"
            });
        }
    }
}
