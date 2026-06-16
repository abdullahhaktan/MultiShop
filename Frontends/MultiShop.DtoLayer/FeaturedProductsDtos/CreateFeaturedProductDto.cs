namespace MultiShop.DtoLayer.FeaturedProductsDtos
{
    public class CreateFeaturedProductDto
    {
        public string ProductName { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public decimal? OldPrice { get; set; }
        public double Rating { get; set; }
        public int ReviewCount { get; set; }
    }
}
