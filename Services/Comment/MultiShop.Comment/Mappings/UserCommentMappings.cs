using AutoMapper;
using MultiShop.Comment.Dto.UserCommentDtos;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Mappings
{
    public class UserCommentMappings:Profile
    {
        public UserCommentMappings()
        {
            CreateMap<UserComment, CreateUserCommentDto>().ReverseMap();
            CreateMap<UserComment, ResultUserCommentDto>();
            CreateMap<UserComment, GetUserCommentByIdDto>();
            CreateMap<UserComment, UpdateUserCommentDto>();
        }
    }
}
