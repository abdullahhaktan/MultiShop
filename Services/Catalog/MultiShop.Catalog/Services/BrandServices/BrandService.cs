using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.BrandDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.BrandServices
{
    public class BrandService : IBrandService
    {
        private readonly IMongoCollection<Brand> _brandCollection;
        private readonly IMapper _mapper;

        public BrandService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _brandCollection = database.GetCollection<Brand>(_databaseSettings.BrandCollectionName);
            _mapper = mapper;
        }

        public async Task CreateBrandAsync(CreateBrandDto createBrandDto)
        {
            if (createBrandDto == null)
                throw new ArgumentNullException(nameof(createBrandDto));

            var value = _mapper.Map<Brand>(createBrandDto);
            await _brandCollection.InsertOneAsync(value);
        }

        public async Task DeleteBrandAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("Id boş olamaz.", nameof(id));

            await _brandCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<ResultBrandDto>> GetAllBrandsAsync()
        {
            var values = await _brandCollection.Find(x => true).ToListAsync();
            if (values == null || values.Count == 0)
                return new List<ResultBrandDto>();

            return _mapper.Map<List<ResultBrandDto>>(values);
        }

        public async Task<GetBrandByIdDto> GetByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("Id boş olamaz.", nameof(id));

            var value = await _brandCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            if (value == null)
                return new GetBrandByIdDto();

            return _mapper.Map<GetBrandByIdDto>(value);
        }

        public async Task UpdateBrandAsync(UpdateBrandDto updateBrandDto)
        {
            if (updateBrandDto == null)
                throw new ArgumentNullException(nameof(updateBrandDto));

            var value = _mapper.Map<Brand>(updateBrandDto);
            await _brandCollection.FindOneAndReplaceAsync(x => x.Id == updateBrandDto.Id, value);
        }
    }
}