using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ContactDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ContactServices
{
    public class ContactService : IContactService
    {
        private readonly IMongoCollection<Contact> _contactCollection;
        private readonly IMapper _mapper;

        public ContactService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _contactCollection = database.GetCollection<Contact>(_databaseSettings.ContactCollectionName);
            _mapper = mapper;
        }

        public async Task CreateContactAsync(CreateContactDto createContactDto)
        {
            if (createContactDto == null)
                throw new ArgumentNullException(nameof(createContactDto));

            createContactDto.SendDate = DateTime.UtcNow;
            var value = _mapper.Map<Contact>(createContactDto);
            await _contactCollection.InsertOneAsync(value);
        }

        public async Task DeleteContactAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("Id boş olamaz.", nameof(id));

            await _contactCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<ResultContactDto>> GetAllContactsAsync()
        {
            var values = await _contactCollection.Find(x => true).ToListAsync();
            if (values == null || values.Count == 0)
                return new List<ResultContactDto>();

            return _mapper.Map<List<ResultContactDto>>(values);
        }

        public async Task<GetContactByIdDto> GetContactByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("Id boş olamaz.", nameof(id));

            var value = await _contactCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            if (value == null)
                return new GetContactByIdDto();

            return _mapper.Map<GetContactByIdDto>(value);
        }

        public async Task UpdateContactAsync(UpdateContactDto updateContactDto)
        {
            if (updateContactDto == null)
                throw new ArgumentNullException(nameof(updateContactDto));

            var value = _mapper.Map<Contact>(updateContactDto);
            await _contactCollection.FindOneAndReplaceAsync(x => x.Id == updateContactDto.Id, value);
        }
    }
}