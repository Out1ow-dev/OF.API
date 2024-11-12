using AutoMapper;
using CrazyApi.Application.Common.Mappings;
using CrazyApi.Application.RCON.Queries.GetPlayers;
using CrazyApi.Application.Users.Commands.CreateUser;

namespace CrazyApi.WebApi.Models
{
    public class CreateUserDto : IMapWith<CreateUserCommand>
    {
        public string UserName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateUserDto, CreateUserCommand>()
                .ForMember(command => command.UserName,
                    opt => opt.MapFrom(dto => dto.UserName));
        }
    }
}
