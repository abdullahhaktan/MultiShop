using MultiShop.DtoLayer.SpecialOfferDtos;

namespace MultiShop.WebUi.Services.Catalog_Services.SpecialOfferServices
{
    public interface ISpecialOfferService
    {
        Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync();
        Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto);
        Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto);
        Task DeleteSpecialOfferAsync(string id);
        Task<GetSpecialOfferByIdDto> GetSpecialOfferByIdAsync(string id);
    }
}
