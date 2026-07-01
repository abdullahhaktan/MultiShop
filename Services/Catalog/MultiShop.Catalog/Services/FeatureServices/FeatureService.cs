using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.FeatureDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.FeatureServices
{
    public class FeatureService : IFeatureService
    {
        private readonly IMongoCollection<Feature> _featureCollection;
        private readonly IMapper _mapper;

        public FeatureService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _featureCollection = database.GetCollection<Feature>(_databaseSettings.FeatureCollectionName);
            _mapper = mapper;
        }

        public async Task CreateFeatureAsync(CreateFeatureDto createFeatureDto)
        {
            if (createFeatureDto == null)
                throw new ArgumentNullException(nameof(createFeatureDto));

            var value = _mapper.Map<Feature>(createFeatureDto);
            await _featureCollection.InsertOneAsync(value);
        }

        public async Task DeleteFeatureAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("Id boş olamaz.", nameof(id));

            await _featureCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<ResultFeatureDto>> GetAllFeaturesAsync()
        {
            var values = await _featureCollection.Find(x => true).ToListAsync();
            if (values == null || values.Count == 0)
                return new List<ResultFeatureDto>();

            return _mapper.Map<List<ResultFeatureDto>>(values);
        }

        public async Task<GetFeatureByIdDto> GetByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("Id boş olamaz.", nameof(id));

            var value = await _featureCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            if (value == null)
                return new GetFeatureByIdDto();

            return _mapper.Map<GetFeatureByIdDto>(value);
        }

        public async Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto)
        {
            if (updateFeatureDto == null)
                throw new ArgumentNullException(nameof(updateFeatureDto));

            var value = _mapper.Map<Feature>(updateFeatureDto);
            await _featureCollection.FindOneAndReplaceAsync(x => x.Id == updateFeatureDto.Id, value);
        }
    }
}