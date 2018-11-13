using System.Collections.Generic;
using Dom.Entities;
using MediatR;

namespace Application.Users.Queries
{
    public class UserQuery : IRequest<List<User>>   
    {
    }
}
