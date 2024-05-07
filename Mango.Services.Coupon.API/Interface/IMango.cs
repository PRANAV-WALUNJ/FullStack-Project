using Mango.Services.Coupon.API.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.Coupon.API.Interface
{
    public interface IMango
    {
        public ResponseDto Get();
        public ResponseDto GetById(int id);
        public ResponseDto GetByIdCode(string code);
        public ResponseDto Create(CouponDto couponDto);
        public ResponseDto Update(CouponDto couponDto);
        public ResponseDto DeleteById(int id);
    }
}
