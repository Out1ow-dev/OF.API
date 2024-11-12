using CrazyApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyApi.Persistence.EntityTypeConfigurations
{
    internal class ServerListConfiguration : IEntityTypeConfiguration<ServerEntity>
    {
        public void Configure(EntityTypeBuilder<ServerEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.
                HasOne(u => u.ServerOwner)
                .WithMany(u => u.ServerList);
        }
    }
}
