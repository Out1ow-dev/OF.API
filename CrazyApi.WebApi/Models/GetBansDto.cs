using AutoMapper;
using CrazyApi.Application.Common.Mappings;
using CrazyApi.Application.RCON.Queries.GetBanList;
using CrazyApi.Application.RCON.Queries.GetPlayers;

namespace CrazyApi.WebApi.Models
{
    public class GetBansDto : IMapWith<GetBanListQuery>
    {
        public Guid ServerGUID { get; set; }
        public Guid ServerOwnerGUID { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<GetBansDto, GetBanListQuery>()
                .ForMember(command => command.ServerGUID,
                    opt => opt.MapFrom(dto => dto.ServerGUID))
                .ForMember(command => command.ServerOwnerGUID,
                    opt => opt.MapFrom(dto => dto.ServerOwnerGUID));
        }
    }
}
