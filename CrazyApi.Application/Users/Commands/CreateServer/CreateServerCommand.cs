using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyApi.Application.Users.Commands.CreateServer
{
    public class CreateServerCommand : IRequest<Guid>
    {
        public Guid ServerId { get; set; }

        public Guid UserId { get; set; }

        public string ServerName { get; set; }

        public string ServerIp{ get; set; }

        public int ServerPort { get; set; }

        public string ServerPassword { get; set; }
    }
}
