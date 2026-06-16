namespace MultiShop.Catalog.Dtos.CategoryDtos
{
    public class GetCategoryByIdDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int? CategoryProductCount { get; set; }
    }
}
