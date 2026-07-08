using MultiShop.DtoLayer.UserCommentDtos;

namespace MultiShop.WebUi.Services.UserCommentServices
{
    public interface IUserCommentService
    {
        Task<List<ResultUserCommentDto>> GetAllUserCommentAsync();
        Task CreateUserCommentAsync(CreateUserCommentDto createUserCommentDto);
        Task UpdateUserCommentAsync(UpdateUserCommentDto updateUserCommentDto);
        Task DeleteUserCommentAsync(string id);
        Task<GetUserCommentByIdDto> GetUserCommentByIdAsync(string id);
        Task<List<ResultUserCommentDto>> GetUserCommentsByProductIdAsync(string id);
    }
}
