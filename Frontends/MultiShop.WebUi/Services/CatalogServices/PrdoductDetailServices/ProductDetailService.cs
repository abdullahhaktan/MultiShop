
using MultiShop.DtoLayer.ProductDetailDtos;

namespace MultiShop.WebUi.Services.CatalogServices.PrdoductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly HttpClient _httpClient;
        public ProductDetailService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<GetProductDetailByIdDto> GetProductDetailByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));

            try
            {
                var responseMessage = await _httpClient.GetAsync("productDetails/" + id);
                if (responseMessage == null)
                    throw new Exception("API'den yanıt alınamadı.");

                var value = await responseMessage.Content.ReadFromJsonAsync<GetProductDetailByIdDto>();
                return value;
            }
            catch (Exception ex)
            {
                throw new Exception("GetProductDetailByIdAsync işlemi sırasında bir hata oluştu.", ex);
            }
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            if (updateProductDetailDto == null)
                throw new ArgumentNullException(nameof(updateProductDetailDto));

            try
            {
                await _httpClient.PutAsJsonAsync<UpdateProductDetailDto>("productDetails", updateProductDetailDto);
            }
            catch (Exception ex)
            {
                throw new Exception("UpdateProductDetailAsync işlemi sırasında bir hata oluştu.", ex);
            }
        }
    }
}
