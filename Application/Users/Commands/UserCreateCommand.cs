using MediatR;

namespace Application.Users.Commands
{
    public class UserCreateCommand : IRequest
    {
        public string Name { get; set; }
    }
}
