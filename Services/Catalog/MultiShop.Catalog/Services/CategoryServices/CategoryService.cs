using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _mapper = mapper;
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var value = _mapper.Map<Category>(createCategoryDto);
            await _categoryCollection.InsertOneAsync(value);
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _categoryCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoriesAsync()
        {
            var values = await _categoryCollection.Find(x => true).ToListAsync();
            var categories = _mapper.Map<List<ResultCategoryDto>>(values);
            foreach (var category in categories)
            {
                category.CategoryProductCount = (int?)await _productCollection.CountDocumentsAsync(p => p.CategoryId == category.Id);
            }
            return categories;
        }

        public async Task<GetCategoryByIdDto> GetByIdAsync(string id)
        {
            var value = await _categoryCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

            return _mapper.Map<GetCategoryByIdDto>(value);
        }

        public async Task<int> GetCategoryProductCountAsync(string id)
        {
            var count = await _productCollection.CountDocumentsAsync(x => x.Id == id);
            return (int)count;
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var value = _mapper.Map<Category>(updateCategoryDto);
            await _categoryCollection.FindOneAndReplaceAsync(x => x.Id == updateCategoryDto.Id, value);
        }
    }
}
