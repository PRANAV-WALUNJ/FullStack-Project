namespace Mango.Services.Coupon.API.Models.DTO
{
    public class CouponDto
    {
        public int CounponId { get; set; }
        public string CounponCode { get; set; }
        public double DiscountAmmount { get; set; }
        public int MinAmmount { get; set; }
    }
}
