using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dom;
using Dom.Entities;
using MediatR;

namespace Application.Users.Commands
{
    public class UserCreateCommandHandler : IRequestHandler<UserCreateCommand, Unit>
    {
        private readonly MyAppContext _context;

        public UserCreateCommandHandler(MyAppContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UserCreateCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Name = request.Name
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
