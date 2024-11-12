using AutoMapper;
using CrazyApi.Application.Common.Mappings;
using CrazyApi.Application.RCON.Commands.BanPlayerByBEID.BanPlayerByBEID;
using CrazyApi.Application.RCON.Queries.GetPlayers;

namespace CrazyApi.WebApi.Models
{
    public class BanPlayerByBEIDDto : IMapWith<BanPlayerByBEIDCommand>
    {
        public Guid ServerGUID { get; set; }
        public Guid ServerOwnerGUID { get; set; }
        public string PlayerBEID { get; set; }
        public string Reason { get; set; }
        public int Duration { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BanPlayerByBEIDDto, BanPlayerByBEIDCommand>()
                .ForMember(command => command.ServerGUID,
                    opt => opt.MapFrom(dto => dto.ServerGUID))
                .ForMember(command => command.ServerOwnerGUID,
                    opt => opt.MapFrom(dto => dto.ServerOwnerGUID))
                .ForMember(command => command.PlayerBEID,
                    opt => opt.MapFrom(dto => dto.PlayerBEID))
                .ForMember(command => command.Reason,
                    opt => opt.MapFrom(dto => dto.Reason))
                .ForMember(command => command.Duration,
                    opt => opt.MapFrom(dto => dto.Duration));
        }
    }
}
