using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyApi.Application.RCON.Queries.GetPlayers
{
    public class PlayersListVM
    {
        public string NickName { get; set; }

        public string IpAdress { get; set; }

        public string BEID { get; set; }

        public string Ping { get; set; }       
    }
}
