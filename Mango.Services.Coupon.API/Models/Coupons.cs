using System.ComponentModel.DataAnnotations;

namespace Mango.Services.Coupon.API.Models
{
    public class Coupons
    {
        [Key]
        public int CounponId { get; set; }
        public string CounponCode { get; set; }
        public double DiscountAmmount { get; set; } 
        public int MinAmmount { get; set; }
       
    }
}
