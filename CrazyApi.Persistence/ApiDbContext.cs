using CrazyApi.Application.Interfaces;
using CrazyApi.Domain.Models;
using CrazyApi.Persistence.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyApi.Persistence
{
    public class ApiDbContext : DbContext, IApiDbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ServerEntity> ServersList { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ServerListConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
