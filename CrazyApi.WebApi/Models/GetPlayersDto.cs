using AutoMapper;
using CrazyApi.Application.Common.Mappings;
using CrazyApi.Application.RCON.Queries.GetPlayers;

namespace CrazyApi.WebApi.Models
{
    public class GetPlayersDto : IMapWith<GetPlayersQuery>
    {
        public Guid ServerGUID { get; set; }
        public Guid ServerOwnerGUID { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<GetPlayersDto, GetPlayersQuery>()
                .ForMember(command => command.ServerGUID,
                    opt => opt.MapFrom(dto => dto.ServerGUID))
                .ForMember(command => command.ServerOwnerGUID,
                    opt => opt.MapFrom(dto => dto.ServerOwnerGUID));
        }
    }
}
