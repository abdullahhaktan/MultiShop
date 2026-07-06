using MultiShop.DtoLayer.CategoryDtos;
using MultiShop.WebUi.Services.CatalogServices.CategoryServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;
        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            if (createCategoryDto == null)
                throw new ArgumentNullException(nameof(createCategoryDto));

            try
            {
                await _httpClient.PostAsJsonAsync("categories", createCategoryDto);
            }
            catch (Exception ex)
            {
                throw new Exception("CreateCategoryAsync işlemi sırasında bir hata oluştu.", ex);
            }
        }

        public async Task DeleteCategoryAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));

            try
            {
                await _httpClient.DeleteAsync($"categories/{id}");
            }
            catch (Exception ex)
            {
                throw new Exception("DeleteCategoryAsync işlemi sırasında bir hata oluştu.", ex);
            }
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            try
            {
                var responseMessage = await _httpClient.GetAsync("categories");
                if (responseMessage == null)
                    throw new Exception("API'den yanıt alınamadı.");

                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(jsonData))
                    return new List<ResultCategoryDto>();

                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return values;
            }
            catch (Exception ex)
            {
                throw new Exception("GetAllCategoryAsync işlemi sırasında bir hata oluştu.", ex);
            }
        }

        public async Task<GetCategoryByIdDto> GetCategoryByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));

            try
            {
                var responseMessage = await _httpClient.GetAsync("categories/" + id);
                if (responseMessage == null)
                    throw new Exception("API'den yanıt alınamadı.");

                var value = await responseMessage.Content.ReadFromJsonAsync<GetCategoryByIdDto>();
                return value;
            }
            catch (Exception ex)
            {
                throw new Exception("GetCategoryByIdAsync işlemi sırasında bir hata oluştu.", ex);
            }
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            if (updateCategoryDto == null)
                throw new ArgumentNullException(nameof(updateCategoryDto));

            try
            {
                await _httpClient.PutAsJsonAsync("categories", updateCategoryDto);
            }
            catch (Exception ex)
            {
                throw new Exception("UpdateCategoryAsync işlemi sırasında bir hata oluştu.", ex);
            }
        }
    }
}