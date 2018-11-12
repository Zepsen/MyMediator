using System.Collections.Generic;
using DAL.Entities;
using MediatR;

namespace Application.Users.Queries
{
    public class UserQuery : IRequest<List<User>>   
    {
    }
}
