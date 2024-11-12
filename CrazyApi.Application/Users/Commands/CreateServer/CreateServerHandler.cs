using CrazyApi.Application.Interfaces;
using CrazyApi.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;

namespace CrazyApi.Application.Users.Commands.CreateServer
{
    internal class CreateServerHandler : IRequestHandler<CreateServerCommand, Guid>
    {
        private readonly IApiDbContext _dbContext;

        public CreateServerHandler(IApiDbContext dbContext) => _dbContext = dbContext;

        public async Task<Guid> Handle(CreateServerCommand request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users
                .FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

            if (user == null)
            {
                throw new Exception("User  not found");
            }

            var server = new ServerEntity
            {
                Id = Guid.NewGuid(),
                ServerName = request.ServerName,
                ServerIp = request.ServerIp,
                ServerPort = request.ServerPort,
                ServerPassword = request.ServerPassword,
                ServerOwner = user,
                ServerOwnerId = user.UserGuid
            };

            user.ServerList ??= new List<ServerEntity>();
            user.ServerList.Add(server);

            await _dbContext.ServersList.AddAsync(server, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return server.Id;
        }
    }

}
