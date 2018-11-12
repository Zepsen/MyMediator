using FluentValidation;

namespace Application.Users.Commands
{
    public class UserCreateCommandValidator : AbstractValidator<UserCreateCommand>
    {
        public UserCreateCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}