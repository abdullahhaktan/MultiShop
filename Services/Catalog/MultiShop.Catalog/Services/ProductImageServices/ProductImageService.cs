using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly IMongoCollection<ProductImage> _productImageCollection;
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMapper _mapper;

        public ProductImageService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productImageCollection = database.GetCollection<ProductImage>(_databaseSettings.ProductImageCollectionName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            var value = _mapper.Map<ProductImage>(createProductImageDto);
            await _productImageCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductImageAsync(string id)
        {
            await _productImageCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImagesAsync()
        {
            var values = await _productImageCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductImageDto>>(values);
        }

        public async Task<List<ResultProductImageWithProductDto>> GetAllProductImagesWithProductAsync()
        {
            var productImages = await _productImageCollection.Find(x => true).ToListAsync();

            foreach (var productImage in productImages)
            {
                productImage.Product = await _productCollection.Find(x => x.Id == productImage.ProductId).FirstOrDefaultAsync();
            }

            return _mapper.Map<List<ResultProductImageWithProductDto>>(productImages);
        }

        public async Task<GetProductImageByIdDto> GetProductImageByIdAsync(string id)
        {
            var value = await _productImageCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<GetProductImageByIdDto>(value);
        }

        public async Task<string> GetProductImageIdByProductIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return string.Empty;
            }

            var value = await _productImageCollection.Find(x => x.ProductId == id).FirstOrDefaultAsync();

            if (value == null)
            {
                return string.Empty;
            }

            return value.Id;
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            var value = _mapper.Map<ProductImage>(updateProductImageDto);
            await _productImageCollection.FindOneAndReplaceAsync(x => x.Id == updateProductImageDto.Id, value);
        }
    }
}
