namespace MultiShop.DtoLayer.CategoryDtos
{
    public class CreateCategoryDto
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int? CategoryProductCount { get; set; }
    }
}
