using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.FeatureSliderSliderServices;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.FeatureSliderServices
{
    public class FeatureSliderService : IFeatureSliderService
    {
        private readonly IMongoCollection<FeatureSlider> _featureCollection;
        private readonly IMapper _mapper;

        public FeatureSliderService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _featureCollection = database.GetCollection<FeatureSlider>(_databaseSettings.FeatureSliderCollectionName);
            _mapper = mapper;
        }

        public async Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto)
        {
            if (createFeatureSliderDto == null)
                throw new ArgumentNullException(nameof(createFeatureSliderDto));

            var value = _mapper.Map<FeatureSlider>(createFeatureSliderDto);
            await _featureCollection.InsertOneAsync(value);
        }

        public async Task DeleteFeatureSliderAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("Id boş olamaz.", nameof(id));

            await _featureCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<ResultFeatureSliderDto>> GetAllFeatureSlidersAsync()
        {
            var values = await _featureCollection.Find(x => true).ToListAsync();
            if (values == null || values.Count == 0)
                return new List<ResultFeatureSliderDto>();

            return _mapper.Map<List<ResultFeatureSliderDto>>(values);
        }

        public async Task<GetFeatureSliderByIdDto> GetFeatureSliderByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("Id boş olamaz.", nameof(id));

            var value = await _featureCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            if (value == null)
                return new GetFeatureSliderByIdDto();

            return _mapper.Map<GetFeatureSliderByIdDto>(value);
        }

        public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            if (updateFeatureSliderDto == null)
                throw new ArgumentNullException(nameof(updateFeatureSliderDto));

            var value = _mapper.Map<FeatureSlider>(updateFeatureSliderDto);
            await _featureCollection.FindOneAndReplaceAsync(x => x.Id == updateFeatureSliderDto.Id, value);
        }
    }
}