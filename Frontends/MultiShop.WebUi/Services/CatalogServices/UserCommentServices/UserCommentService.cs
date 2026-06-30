using MultiShop.DtoLayer.UserCommentDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUi.Services.CatalogServices.UserCommentServices
{
    public class UserCommentService : IUserCommentService
    {
        private readonly HttpClient _httpClient;
        public UserCommentService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task CreateUserCommentAsync(CreateUserCommentDto createUserCommentDto)
        {
            if (createUserCommentDto == null)
                throw new ArgumentNullException(nameof(createUserCommentDto));

            try
            {
                await _httpClient.PostAsJsonAsync<CreateUserCommentDto>("userComments", createUserCommentDto);
            }
            catch (Exception ex)
            {
                throw new Exception("CreateUserCommentAsync işlemi sırasında bir hata oluştu.", ex);
            }
        }

        public async Task DeleteUserCommentAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));

            try
            {
                await _httpClient.DeleteAsync($"userComments/{id}");
            }
            catch (Exception ex)
            {
                throw new Exception("DeleteUserCommentAsync işlemi sırasında bir hata oluştu.", ex);
            }
        }

        public async Task<List<ResultUserCommentDto>> GetAllUserCommentAsync()
        {
            try
            {
                var responseMessage = await _httpClient.GetAsync("userComments");
                if (responseMessage == null)
                    throw new Exception("API'den yanıt alınamadı.");

                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(jsonData))
                    return new List<ResultUserCommentDto>();

                var values = JsonConvert.DeserializeObject<List<ResultUserCommentDto>>(jsonData);
                return values;
            }
            catch (Exception ex)
            {
                throw new Exception("GetAllUserCommentAsync işlemi sırasında bir hata oluştu.", ex);
            }
        }

        public async Task<GetUserCommentByIdDto> GetUserCommentByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));

            try
            {
                var responseMessage = await _httpClient.GetAsync("userComments/" + id);
                if (responseMessage == null)
                    throw new Exception("API'den yanıt alınamadı.");

                var value = await responseMessage.Content.ReadFromJsonAsync<GetUserCommentByIdDto>();
                return value;
            }
            catch (Exception ex)
            {
                throw new Exception("GetUserCommentByIdAsync işlemi sırasında bir hata oluştu.", ex);
            }
        }

        public async Task UpdateUserCommentAsync(UpdateUserCommentDto updateUserCommentDto)
        {
            if (updateUserCommentDto == null)
                throw new ArgumentNullException(nameof(updateUserCommentDto));

            try
            {
                await _httpClient.PutAsJsonAsync<UpdateUserCommentDto>("userComments", updateUserCommentDto);
            }
            catch (Exception ex)
            {
                throw new Exception("UpdateUserCommentAsync işlemi sırasında bir hata oluştu.", ex);
            }
        }
    }
}
