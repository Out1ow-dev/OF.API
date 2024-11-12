using CrazyApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CrazyApi.Application.Interfaces
{
    public interface IApiDbContext
    {
        DbSet<UserEntity> Users { get; set; }
        DbSet<ServerEntity> ServersList { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
