using CrazyApi.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace CrazyApi.Application.Users.Queries.GetUsersList
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserListVM>>
    {
        private readonly IApiDbContext _dbContext;

        public GetAllUsersQueryHandler(IApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<UserListVM>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _dbContext.Users
                .Include(u => u.ServerList) 
                .ToListAsync(cancellationToken);

            return users.Select(user => new UserListVM
            {
                Id = user.Id,
                UserName = user.UserName,
                Servers = user.ServerList.Select(server => new ServerListVM
                {
                    Id = server.Id,
                    ServerName = server.ServerName
                }).ToList() // Проекция серверов
            }).ToList();
        }
    }


}
