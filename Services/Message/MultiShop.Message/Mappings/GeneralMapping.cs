using AutoMapper;
using MultiShop.Message.DAL.Entites;
using MultiShop.Message.DTOs;

namespace MultiShop.Message.Mappings
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<UserMessage, ResultMessageDto>().ReverseMap();
            CreateMap<UserMessage, CreateMessageDto>().ReverseMap();
            CreateMap<UserMessage, UpdateMessageDto>().ReverseMap();
            CreateMap<UserMessage, ResultInboxMessageDto>().ReverseMap();
            CreateMap<UserMessage, ResultSendboxMessageDto>().ReverseMap();
            CreateMap<UserMessage, GetMessageByIdDto>().ReverseMap();
        }
    }
}
