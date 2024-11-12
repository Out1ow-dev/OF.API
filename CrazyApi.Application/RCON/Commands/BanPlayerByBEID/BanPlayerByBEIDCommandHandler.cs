using BattlEye.V6;
using CrazyApi.Application.Interfaces;
using CrazyApi.Application.RCON.Commands.BanPlayerByBEID.BanPlayerByBEID;
using MediatR;


namespace CrazyApi.Application.RCON.Commands.BanPlayerByBEID
{
    public class BanPlayerByBEIDCommandHandler : IRequestHandler<BanPlayerByBEIDCommand, string>
    {
        private readonly IApiDbContext _dbContext;
        private BEClient _beClient;

        public BanPlayerByBEIDCommandHandler(IApiDbContext dbContext) =>
            _dbContext = dbContext;

        async Task<string> IRequestHandler<BanPlayerByBEIDCommand, string>.Handle(BanPlayerByBEIDCommand request, CancellationToken cancellationToken)
        {
            var server = _dbContext.ServersList.FirstOrDefault(s => s.Id == request.ServerGUID);

            if (server != null)
            {
                if (server.ServerOwnerId == request.ServerOwnerGUID)
                {
                    _beClient = BEClient.New(server.ServerIp, server.ServerPort, server.ServerPassword);
                    _beClient.Connect();
                    await Task.Delay(700);
                    _beClient.BanOffline(request.PlayerBEID, request.Duration, request.Reason);

                    await Task.Delay(300);
                    _beClient.Disconnect();

                    return "User banned success";
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

            throw new NotImplementedException();
        }
    }
}
