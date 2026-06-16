namespace MultiShop.Catalog.Dtos.SpecialOfferDtos
{
    public class GetSpecialOfferByIdDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public int DiscountRate { get; set; }
        public string ImageUrl { get; set; }
    }
}
