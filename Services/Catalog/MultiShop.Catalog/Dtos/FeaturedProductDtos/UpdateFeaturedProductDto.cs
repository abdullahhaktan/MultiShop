namespace MultiShop.Catalog.Dtos.FeaturedProductDtos
{
    public class UpdateFeaturedProductDto
    {
        public string Id { get; set; }
        public string ProductName { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public decimal? OldPrice { get; set; }
        public double Rating { get; set; }
        public int ReviewCount { get; set; }
    }
}
