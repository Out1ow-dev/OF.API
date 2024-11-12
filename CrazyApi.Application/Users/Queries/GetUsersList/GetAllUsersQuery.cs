using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyApi.Application.Users.Queries.GetUsersList
{
    public class GetAllUsersQuery : IRequest<List<UserListVM>>
    {

    }
}
