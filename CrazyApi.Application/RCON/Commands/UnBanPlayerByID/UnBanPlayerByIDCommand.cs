using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyApi.Application.RCON.Commands.UnBanPlayerByID
{
    public class UnBanPlayerByIDCommand : IRequest<string>
    {
        public Guid ServerGUID { get; set; }
        public Guid ServerOwnerGUID { get; set; }
        public int BanId { get; set; }
    }
}
