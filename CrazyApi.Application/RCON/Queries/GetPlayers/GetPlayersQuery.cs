using MediatR;

namespace CrazyApi.Application.RCON.Queries.GetPlayers
{
    public class GetPlayersQuery : IRequest<List<PlayersListVM>>
    {
        public Guid ServerGUID { get; set; }
        public Guid ServerOwnerGUID { get; set; }
    }
}
