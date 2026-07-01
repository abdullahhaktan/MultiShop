using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.FeaturedProductDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.FeaturedProductServices
{
    public class FeaturedProductService : IFeaturedProductService
    {
        private readonly IMongoCollection<FeaturedProduct> _featuredProductCollection;
        private readonly IMapper _mapper;

        public FeaturedProductService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _featuredProductCollection = database.GetCollection<FeaturedProduct>(_databaseSettings.FeaturedProductCollectionName);
            _mapper = mapper;
        }

        public async Task CreateFeaturedProductAsync(CreateFeaturedProductDto createFeaturedProductDto)
        {
            if (createFeaturedProductDto == null)
                throw new ArgumentNullException(nameof(createFeaturedProductDto));

            var value = _mapper.Map<FeaturedProduct>(createFeaturedProductDto);
            await _featuredProductCollection.InsertOneAsync(value);
        }

        public async Task DeleteFeaturedProductAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("Id boş olamaz.", nameof(id));

            await _featuredProductCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<ResultFeaturedProductDto>> GetAllFeaturedProductsAsync()
        {
            var values = await _featuredProductCollection.Find(x => true).ToListAsync();
            if (values == null || values.Count == 0)
                return new List<ResultFeaturedProductDto>();

            return _mapper.Map<List<ResultFeaturedProductDto>>(values);
        }

        public async Task<GetFeaturedProductByIdDto> GetFeaturedProductByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("Id boş olamaz.", nameof(id));

            var value = await _featuredProductCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            if (value == null)
                return new GetFeaturedProductByIdDto();

            return _mapper.Map<GetFeaturedProductByIdDto>(value);
        }

        public async Task UpdateFeaturedProductAsync(UpdateFeaturedProductDto updateFeaturedProductDto)
        {
            if (updateFeaturedProductDto == null)
                throw new ArgumentNullException(nameof(updateFeaturedProductDto));

            var value = _mapper.Map<FeaturedProduct>(updateFeaturedProductDto);
            await _featuredProductCollection.FindOneAndReplaceAsync(x => x.Id == updateFeaturedProductDto.Id, value);
        }
    }
}