using MultiShop.Catalog.Dtos.ProductDtos;

namespace MultiShop.Catalog.Dtos.ProductDetailDtos
{
    public class GetProductDetailByIdDto
    {
        public string Id { get; set; }
        public string ProductDescription { get; set; }
        public string ProductInfo { get; set; }
        public string FeatureOne { get; set; }
        public string FeatureTwo { get; set; }
        public string FeatureThree { get; set; }
        public string FeatureFour { get; set; }
        public string FeatureFive { get; set; }
        public string FeatureSix { get; set; }
        public string FeatureSeven { get; set; }
        public string FeatureEight { get; set; }
        public string ProductId { get; set; }
        public ResultProductDto Product { get; set; }
    }
}
