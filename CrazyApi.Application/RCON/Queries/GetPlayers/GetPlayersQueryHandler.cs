using BattlEye.V6;
using CrazyApi.Application.Interfaces;
using MediatR;

namespace CrazyApi.Application.RCON.Queries.GetPlayers
{
    public class GetPlayersQueryHandler : IRequestHandler<GetPlayersQuery, List<PlayersListVM>>
    {
        private readonly IApiDbContext _dbContext;
        private BEClient _beClient;

        public GetPlayersQueryHandler(IApiDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<List<PlayersListVM>> Handle(GetPlayersQuery request, CancellationToken cancellationToken)
        {
            var server = _dbContext.ServersList.FirstOrDefault(s => s.Id == request.ServerGUID);

            if (server != null) 
            {
                if (server.ServerOwnerId == request.ServerOwnerGUID) 
                {
                    _beClient = BEClient.New(server.ServerIp, server.ServerPort, server.ServerPassword);
                    _beClient.Connect();

                    var players = _beClient.GetPlayers();

                    var playersListVm = players.Select(player => new PlayersListVM
                    {
                        NickName = player.Nickname,
                        IpAdress = player.IP,
                        BEID = player.BEID,
                        Ping = "0"
                    }).ToList();

                    _beClient.Disconnect();

                    return playersListVm;
                }
                else
                {
                    throw new Exception("You not Server Owner");
                }
            }         
            else
            {
                throw new Exception("Server not found");
            }
        }
    }

}
