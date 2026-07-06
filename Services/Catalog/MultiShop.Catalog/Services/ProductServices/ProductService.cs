using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            if (createProductDto == null)
                throw new ArgumentNullException(nameof(createProductDto));

            var value = _mapper.Map<Product>(createProductDto);
            await _productCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("Id boş olamaz.", nameof(id));

            await _productCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductsWithCategoriesAsync()
        {
            var products = await _productCollection.Find(x => true).ToListAsync();
            if (products == null || products.Count == 0)
                return new List<ResultProductWithCategoryDto>();

            foreach (var product in products)
            {
                if (product != null)
                {
                    product.Category = await _categoryCollection.Find(x => x.Id == product.CategoryId).FirstOrDefaultAsync();
                }
            }

            return _mapper.Map<List<ResultProductWithCategoryDto>>(products);
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductsWithCategoriesByCategoryAsync(string categoryId)
        {
            if (string.IsNullOrEmpty(categoryId))
                throw new ArgumentException("CategoryId boş olamaz.", nameof(categoryId));

            var products = await _productCollection.Find(p => p.CategoryId == categoryId).ToListAsync();
            if (products == null || products.Count == 0)
                return new List<ResultProductWithCategoryDto>();

            foreach (var product in products)
            {
                if (product != null)
                {
                    product.Category = await _categoryCollection.Find(x => x.Id == product.CategoryId).FirstOrDefaultAsync();
                }
            }

            return _mapper.Map<List<ResultProductWithCategoryDto>>(products);
        }

        public async Task<List<ResultProductDto>> GetAllProductsAsync()
        {
            var products = await _productCollection.Find(x => true).ToListAsync();
            if (products == null || products.Count == 0)
                return new List<ResultProductDto>();

            foreach (var product in products)
            {
                if (product != null)
                {
                    product.Category = await _categoryCollection.Find(x => x.Id == product.CategoryId).FirstOrDefaultAsync();
                }
            }

            return _mapper.Map<List<ResultProductDto>>(products);
        }

        public async Task<GetProductByIdDto> GetProductByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("Id boş olamaz.", nameof(id));

            var value = await _productCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            if (value == null)
                return new GetProductByIdDto();

            return _mapper.Map<GetProductByIdDto>(value);
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            if (updateProductDto == null)
                throw new ArgumentNullException(nameof(updateProductDto));

            var value = _mapper.Map<Product>(updateProductDto);
            await _productCollection.FindOneAndReplaceAsync(x => x.Id == updateProductDto.Id, value);
        }

        public async Task<string> GetProductIdByProductName(string productName)
        {
            if (string.IsNullOrEmpty(productName))
                throw new ArgumentException("Name boş olamaz.", nameof(productName));

            var value = await _productCollection.Find(p => p.ProductName == productName).FirstOrDefaultAsync();

            return value.Id;
        }
    }
}