using MultiShop.DtoLayer.ContactDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUi.Services.CatalogServices.ContactServices
{
    public class ContactService : IContactService
    {
        private readonly HttpClient _httpClient;
        public ContactService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task CreateContactAsync(CreateContactDto createContactDto)
        {
            if (createContactDto == null)
                throw new ArgumentNullException(nameof(createContactDto));

            try
            {
                var response = await _httpClient.PostAsJsonAsync("contacts", createContactDto);

                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                throw new Exception("CreateContactAsync işlemi sırasında bir hata oluştu.", ex);
            }
        }

        public async Task DeleteContactAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));

            try
            {
                await _httpClient.DeleteAsync($"contacts/{id}");
            }
            catch (Exception ex)
            {
                throw new Exception("DeleteContactAsync işlemi sırasında bir hata oluştu.", ex);
            }
        }

        public async Task<List<ResultContactDto>> GetAllContactAsync()
        {
            try
            {
                var responseMessage = await _httpClient.GetAsync("contacts");
                if (responseMessage == null)
                    throw new Exception("API'den yanıt alınamadı.");

                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(jsonData))
                    return new List<ResultContactDto>();

                var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
                return values;
            }
            catch (Exception ex)
            {
                throw new Exception("GetAllContactAsync işlemi sırasında bir hata oluştu.", ex);
            }
        }

        public async Task<GetContactByIdDto> GetContactByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));

            try
            {
                var responseMessage = await _httpClient.GetAsync("contacts/" + id);
                if (responseMessage == null)
                    throw new Exception("API'den yanıt alınamadı.");

                var value = await responseMessage.Content.ReadFromJsonAsync<GetContactByIdDto>();
                return value;
            }
            catch (Exception ex)
            {
                throw new Exception("GetContactByIdAsync işlemi sırasında bir hata oluştu.", ex);
            }
        }

        public async Task UpdateContactAsync(UpdateContactDto updateContactDto)
        {
            if (updateContactDto == null)
                throw new ArgumentNullException(nameof(updateContactDto));

            try
            {
                await _httpClient.PutAsJsonAsync("contacts", updateContactDto);
            }
            catch (Exception ex)
            {
                throw new Exception("UpdateContactAsync işlemi sırasında bir hata oluştu.", ex);
            }
        }
    }
}
