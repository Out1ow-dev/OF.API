using AutoMapper;
using CrazyApi.Application.RCON.Commands.BanPlayerByBEID.BanPlayerByBEID;
using CrazyApi.Application.RCON.Commands.SendGlobalMessage;
using CrazyApi.Application.RCON.Commands.UnBanPlayerByID;
using CrazyApi.Application.RCON.Queries.GetBanList;
using CrazyApi.Application.RCON.Queries.GetPlayers;
using CrazyApi.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrazyApi.WebApi.Controllers
{
    public class RCONController : BaseController
    {
        private readonly IMapper _mapper;
        public RCONController(IMapper mapper) => _mapper = mapper;

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<string>> SendGlobalMessage([FromBody] SendGlobalMessageDto sendGlobalMessageDto)
        {
            var command = _mapper.Map<SendGlobalMessageCommand>(sendGlobalMessageDto);
            var vm = await Mediator.Send(command);
            return Ok(vm);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<string>> BanPlayerByBEID([FromBody] BanPlayerByBEIDDto banPlayerByBEIDDto)
        {
            var command = _mapper.Map<BanPlayerByBEIDCommand>(banPlayerByBEIDDto);
            var vm = await Mediator.Send(command);
            return Ok(vm);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<string>> UnBanPlayerById([FromBody] UnBanPlayerByIDDto unBanPlayerByIDDto)
        {
            var command = _mapper.Map<UnBanPlayerByIDCommand>(unBanPlayerByIDDto);
            var vm = await Mediator.Send(command);
            return Ok(vm);
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<PlayersListVM>>> GetPlayers([FromQuery] GetPlayersDto getPlayersDto)
        {
            var command = _mapper.Map<GetPlayersQuery>(getPlayersDto);
            var vm = await Mediator.Send(command);
            return Ok(vm);
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<BanListVM>>> GetBans([FromQuery] GetBansDto getBansDto)
        {
            var command = _mapper.Map<GetBanListQuery>(getBansDto);
            var vm = await Mediator.Send(command);
            return Ok(vm);
        }
    }
}
