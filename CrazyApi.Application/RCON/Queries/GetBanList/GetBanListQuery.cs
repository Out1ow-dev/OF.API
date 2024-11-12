using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyApi.Application.RCON.Queries.GetBanList
{
    public class GetBanListQuery : IRequest<List<BanListVM>>
    {
        public Guid ServerGUID { get; set; }
        public Guid ServerOwnerGUID { get; set; }
    }
}
