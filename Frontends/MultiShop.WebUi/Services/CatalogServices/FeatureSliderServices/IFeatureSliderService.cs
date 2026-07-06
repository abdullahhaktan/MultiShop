using MultiShop.DtoLayer.FeatureSliderDtos;

namespace MultiShop.WebUi.Services.CatalogServices.FeatureSliderServices
{
    public interface IFeatureSliderService
    {
        Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync();
        Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto);
        Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto);
        Task DeleteFeatureSliderAsync(string id);
        Task<GetFeatureSliderByIdDto> GetFeatureSliderByIdAsync(string id);
    }
}
