using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyApi.Application.Users.Queries.GetUsersList
{
    public class ServerListVM
    {
        public Guid Id { get; set; }
        public string ServerName { get; set; } = string.Empty;
    }
}
