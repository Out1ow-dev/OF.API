using BattlEye.V6;
using CrazyApi.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyApi.Application.RCON.Commands.UnBanPlayerByID
{
    public class UnBanPlayerByIDCommandHandler : IRequestHandler<UnBanPlayerByIDCommand, string>
    {
        private readonly IApiDbContext _dbContext;
        private BEClient _beClient;

        public UnBanPlayerByIDCommandHandler(IApiDbContext dbContext) => 
            _dbContext = dbContext;

        public async Task<string> Handle(UnBanPlayerByIDCommand request, CancellationToken cancellationToken)
        {
            var server = _dbContext.ServersList.FirstOrDefault(s => s.Id == request.ServerGUID);

            if (server != null)
            {
                if (server.ServerOwnerId == request.ServerOwnerGUID)
                {
                    _beClient = BEClient.New(server.ServerIp, server.ServerPort, server.ServerPassword);            
                    _beClient.Connect();
                    await Task.Delay(700);
                    _beClient.Unban(request.BanId);
                    await Task.Delay(300);
                    _beClient.Disconnect();

                    return "User unbanned success";
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
