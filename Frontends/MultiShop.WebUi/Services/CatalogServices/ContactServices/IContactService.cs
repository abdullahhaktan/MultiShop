using MultiShop.DtoLayer.ContactDtos;

namespace MultiShop.WebUi.Services.CatalogServices.ContactServices
{
    public interface IContactService
    {
        Task<List<ResultContactDto>> GetAllContactAsync();
        Task CreateContactAsync(CreateContactDto createContactDto);
        Task UpdateContactAsync(UpdateContactDto updateContactDto);
        Task DeleteContactAsync(string id);
        Task<GetContactByIdDto> GetContactByIdAsync(string id);
    }
}
