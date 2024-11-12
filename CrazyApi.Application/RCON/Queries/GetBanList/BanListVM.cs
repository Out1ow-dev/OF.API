using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyApi.Application.RCON.Queries.GetBanList
{
    public class BanListVM
    {
        public int Id { get; set; }

        public string IPAdress { get; set; }

        public string BEID { get; set; }

        public string Reason { get; set; }

        public string Duration { get; set; }
    }
}
