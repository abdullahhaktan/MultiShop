
using MongoDB.Bson;
using MongoDB.Driver;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.StatisticServices
{
    public class StatisticService : IStatisticService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMongoCollection<Brand> _brandCollection;

        public StatisticService(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _brandCollection = database.GetCollection<Brand>(_databaseSettings.BrandCollectionName);
        }

        public async Task<long> GetBrandCount()
        {
            return await _brandCollection.CountDocumentsAsync(FilterDefinition<Brand>.Empty);
        }

        public Task<long> GetCategoryCount()
        {
            return _categoryCollection.CountDocumentsAsync(FilterDefinition<Category>.Empty);
        }

        public async Task<string> GetMaxPriceProductName()
        {
            var product = await _productCollection.Find(FilterDefinition<Product>.Empty).SortByDescending(p => p.Price).FirstOrDefaultAsync();
            return product?.ProductName ?? string.Empty;
        }

        public async Task<string> GetMinPriceProductName()
        {
            var product = await _productCollection.Find(FilterDefinition<Product>.Empty).SortBy(p => p.Price).FirstOrDefaultAsync();
            return product?.ProductName ?? string.Empty;
        }

        public async Task<decimal> GetProductAvgPrice()
        {
            var result = await _productCollection.Aggregate().Group(x => 1, g => new
            {
                AvgPrice = g.Average(p => p.Price)
            }).FirstOrDefaultAsync();

            return result?.AvgPrice ?? 0;
        }

        public async Task<long> GetProductCount()
        {
            return await _productCollection.CountDocumentsAsync(FilterDefinition<Product>.Empty);
        }
    }
}
