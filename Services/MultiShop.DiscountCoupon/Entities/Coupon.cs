using System.ComponentModel.DataAnnotations;

namespace MultiShop.DiscountCoupon.Entities
{
    public class Coupon
    {
        [Key]
        public int DiscountCouponId { get; set; }
        public string Code { get; set; }
        public int Rate { get; set; }
        public bool IsActive { get; set; }
        public DateTime ValidDate { get; set; }
    }
}
