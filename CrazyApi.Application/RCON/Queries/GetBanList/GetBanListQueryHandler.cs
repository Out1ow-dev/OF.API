using BattlEye.V6;
using CrazyApi.Application.Interfaces;
using CrazyApi.Application.RCON.Queries.GetPlayers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyApi.Application.RCON.Queries.GetBanList
{
    public class GetBanListQueryHandler : IRequestHandler<GetBanListQuery, List<BanListVM>>
    {
        private readonly IApiDbContext _dbContext;
        private BEClient _beClient;

        public GetBanListQueryHandler(IApiDbContext dbContext) => 
            _dbContext = dbContext;

        public async Task<List<BanListVM>> Handle(GetBanListQuery request, CancellationToken cancellationToken)
        {
            var server = _dbContext.ServersList.FirstOrDefault(s => s.Id == request.ServerGUID);

            if (server != null)
            {
                if (server.ServerOwnerId == request.ServerOwnerGUID)
                {
                    _beClient = BEClient.New(server.ServerIp, server.ServerPort, server.ServerPassword);
                    _beClient.Connect();

                    var bans = _beClient.GetBans();

                    var bansListVm = bans.Select(ban => new BanListVM
                    {
                        Id = ban.ID,
                        IPAdress = ban.IP,
                        BEID = ban.BEID,
                        Duration = ban.Term,
                        Reason = ban.Reason
                    }).ToList();

                    _beClient.Disconnect();

                    return bansListVm;
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
