using MultiShop.Catalog.Dtos.ProductDtos;

namespace MultiShop.Catalog.Dtos.ProductDetailDtos
{
    public class GetProductDetailByIdDto
    {
        public string Id { get; set; }
        public string ProductDescription { get; set; }
        public string ProductInfo { get; set; }

        public string ProductId { get; set; }
        public ResultProductDto Product { get; set; }
    }
}
