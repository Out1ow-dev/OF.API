using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CrazyApi.Domain.Models
{
    public class ServerEntity
    {
        public Guid Id { get; set; }

        public string ServerName { get; set; } = string.Empty;

        public string ServerIp { get; set; } = string.Empty;

        public int ServerPort { get; set; }

        public string ServerPassword { get; set; } = string.Empty;

        [JsonIgnore]
        public Guid ServerOwnerId { get; set; }

        public UserEntity? ServerOwner { get; set; }
    }
}
