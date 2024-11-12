using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyApi.Application.RCON.Commands.SendGlobalMessage
{
    public class SendGlobalMessageCommand : IRequest<string>
    {
        public Guid ServerGUID { get; set; }
        public Guid ServerOwnerGUID { get; set; }
        public string Message { get; set; }
    }
}
