using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dom;
using Dom.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Queries
{
    public class UserQueryHandler : IRequestHandler<UserQuery, List<User>>
    {
        private readonly MyAppContext _context;

        public UserQueryHandler(MyAppContext context)
        {
            _context = context;
        }

        public async Task<List<User>> Handle(UserQuery request, CancellationToken cancellationToken)
        {
            return await _context.Users.ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
