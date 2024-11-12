using AutoMapper;
using CrazyApi.Application.Common.Mappings;
using CrazyApi.Application.Users.Commands.CreateServer;
using CrazyApi.Application.Users.Commands.CreateUser;

namespace CrazyApi.WebApi.Models
{
    public class CreateServerDto : IMapWith<CreateServerCommand>
    {
        public Guid UserId { get; set; }

        public string ServerName { get; set; }

        public string ServerIp { get; set; }

        public int ServerPort { get; set; }

        public string ServerPassword { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateServerDto, CreateServerCommand>()
                .ForMember(command => command.UserId,
                    opt => opt.MapFrom(dto => dto.UserId))
                .ForMember(command => command.ServerName,
                    opt => opt.MapFrom(dto => dto.ServerName))
                .ForMember(command => command.ServerIp,
                    opt => opt.MapFrom(dto => dto.ServerIp))
                .ForMember(command => command.ServerPort,
                    opt => opt.MapFrom(dto => dto.ServerPort))
                .ForMember(command => command.ServerPassword,
                    opt => opt.MapFrom(dto => dto.ServerPassword));
        }
    }
}
