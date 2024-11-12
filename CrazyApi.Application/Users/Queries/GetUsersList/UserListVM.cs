using CrazyApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyApi.Application.Users.Queries.GetUsersList
{
    public class UserListVM
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public List<ServerListVM> Servers { get; set; } = new List<ServerListVM>();
    }
}
