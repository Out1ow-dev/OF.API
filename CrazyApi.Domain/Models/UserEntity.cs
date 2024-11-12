using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyApi.Domain.Models
{
    public class UserEntity
    {
        public Guid Id { get; set; }

        public Guid UserGuid { get; set; }

        public string UserName { get; set; } = string.Empty;
        
        public string SubscriptionLevel { get; set; } = string.Empty;

        public List<ServerEntity>? ServerList { get; set; }
    }
}
