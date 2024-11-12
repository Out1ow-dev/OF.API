using AutoMapper;
using CrazyApi.Application.RCON.Commands.BanPlayerByBEID.BanPlayerByBEID;
using CrazyApi.Application.RCON.Commands.SendGlobalMessage;
using CrazyApi.Application.RCON.Commands.UnBanPlayerByID;
using CrazyApi.Application.RCON.Queries.GetBanList;
using CrazyApi.Application.RCON.Queries.GetPlayers;
using CrazyApi.Application.Users.Commands.CreateServer;
using CrazyApi.Application.Users.Commands.CreateUser;
using CrazyApi.Application.Users.Queries.GetUsersList;
using CrazyApi.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrazyApi.WebApi.Controllers
{
    public class UserController : BaseController
    {
        private readonly IMapper _mapper;
        public UserController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Deletes a specific TodoItem.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Guid>> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            var command = _mapper.Map<CreateUserCommand>(createUserDto);
            var vm = await Mediator.Send(command);
            return Ok(vm);
        }          

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<UserListVM>>> GetAll()
        {
            var query = new GetAllUsersQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }     
    }
}
