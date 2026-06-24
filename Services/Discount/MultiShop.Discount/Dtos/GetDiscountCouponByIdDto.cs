namespace MultiShop.Discount.Dtos
{
    public class GetDiscountByIdDto
    {
        public int DiscountId { get; set; }
        public string Code { get; set; }
        public int Rate { get; set; }
        public bool IsActive { get; set; }
        public DateTime ValidDate { get; set; }
    }
}
