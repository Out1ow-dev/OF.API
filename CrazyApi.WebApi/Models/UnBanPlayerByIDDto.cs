using AutoMapper;
using CrazyApi.Application.Common.Mappings;
using CrazyApi.Application.RCON.Commands.SendGlobalMessage;
using CrazyApi.Application.RCON.Commands.UnBanPlayerByID;

namespace CrazyApi.WebApi.Models
{
    public class UnBanPlayerByIDDto : IMapWith<UnBanPlayerByIDCommand>
    {
        public Guid ServerGUID { get; set; }
        public Guid ServerOwnerGUID { get; set; }
        public int BanId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UnBanPlayerByIDDto, UnBanPlayerByIDCommand>()
                .ForMember(command => command.ServerGUID,
                    opt => opt.MapFrom(dto => dto.ServerGUID))
                .ForMember(command => command.ServerOwnerGUID,
                    opt => opt.MapFrom(dto => dto.ServerOwnerGUID))
                .ForMember(command => command.BanId,
                    opt => opt.MapFrom(dto => dto.BanId));
        }
    }
}
