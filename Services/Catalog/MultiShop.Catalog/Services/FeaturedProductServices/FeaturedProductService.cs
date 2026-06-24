using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.FeaturedProductDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.FeaturedProductServices
{
    public class FeaturedProductService : IFeaturedProductService
    {
        private readonly IMongoCollection<FeaturedProduct> _specialOfferCollection;
        private readonly IMapper _mapper;

        public FeaturedProductService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _specialOfferCollection = database.GetCollection<FeaturedProduct>(_databaseSettings.FeaturedProductCollectionName);
            _mapper = mapper;
        }

        public async Task CreateFeaturedProductAsync(CreateFeaturedProductDto createFeaturedProductDto)
        {
            var value = _mapper.Map<FeaturedProduct>(createFeaturedProductDto);
            await _specialOfferCollection.InsertOneAsync(value);
        }

        public async Task DeleteFeaturedProductAsync(string id)
        {
            await _specialOfferCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<ResultFeaturedProductDto>> GetAllFeaturedProductsAsync()
        {
            var values = await _specialOfferCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultFeaturedProductDto>>(values);
        }

        public async Task<GetFeaturedProductByIdDto> GetByIdAsync(string id)
        {
            var value = await _specialOfferCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<GetFeaturedProductByIdDto>(value);
        }

        public async Task UpdateFeaturedProductAsync(UpdateFeaturedProductDto updateFeaturedProductDto)
        {
            var value = _mapper.Map<FeaturedProduct>(updateFeaturedProductDto);
            await _specialOfferCollection.FindOneAndReplaceAsync(x => x.Id == updateFeaturedProductDto.Id, value);
        }
    }
}
