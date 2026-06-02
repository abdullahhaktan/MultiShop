using System.ComponentModel.DataAnnotations;

namespace MultiShop.Discount.Entities
{
    public class DiscountCoupon
    {
        [Key]
        public int DiscountId { get; set; }
        public string Code { get; set; }
        public int Rate { get; set; }
        public bool IsActive { get; set; }
        public DateTime ValidDate { get; set; }
    }
}
