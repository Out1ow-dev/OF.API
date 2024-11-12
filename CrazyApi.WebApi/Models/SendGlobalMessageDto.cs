using AutoMapper;
using CrazyApi.Application.Common.Mappings;
using CrazyApi.Application.RCON.Commands.SendGlobalMessage;

namespace CrazyApi.WebApi.Models
{
    public class SendGlobalMessageDto : IMapWith<SendGlobalMessageCommand>
    {
        public Guid ServerGUID { get; set; }
        public Guid ServerOwnerGUID { get; set; }
        public string Message { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SendGlobalMessageDto, SendGlobalMessageCommand>()
                .ForMember(command => command.ServerGUID,
                    opt => opt.MapFrom(dto => dto.ServerGUID))
                .ForMember(command => command.ServerOwnerGUID,
                    opt => opt.MapFrom(dto => dto.ServerOwnerGUID))
                .ForMember(command => command.Message,
                    opt => opt.MapFrom(dto => dto.Message));
        }
    }
}
