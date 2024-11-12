using MediatR;

namespace CrazyApi.Application.RCON.Commands.BanPlayerByBEID.BanPlayerByBEID
{
    public class BanPlayerByBEIDCommand : IRequest<string>
    {
        public Guid ServerGUID { get; set; }
        public Guid ServerOwnerGUID { get; set; }
        public string PlayerBEID { get; set; }
        public string Reason { get; set; }
        public int Duration { get; set; }
    }
}
