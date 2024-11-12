using AutoMapper;
using CrazyApi.Application.Users.Commands.CreateServer;
using CrazyApi.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrazyApi.WebApi.Controllers
{
    public class ServerController : BaseController
    {
        private readonly IMapper _mapper;
        public ServerController(IMapper mapper) => _mapper = mapper;

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Guid>> CreateServer([FromBody] CreateServerDto createServerDto)
        {
            var command = _mapper.Map<CreateServerCommand>(createServerDto);
            var vm = await Mediator.Send(command);
            return Ok(vm);
        }
    }
}
