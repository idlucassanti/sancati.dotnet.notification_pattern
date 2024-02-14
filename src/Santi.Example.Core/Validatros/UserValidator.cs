using FluentValidation;
using Santi.Example.Core.Domain.Entities;

namespace Santi.Example.Core.Validatros
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .WithMessage("Enter the User name!");

            RuleFor(a => a.PhoneNumber)
                .NotEmpty()
                .WithMessage("Enter the User phone number!");

            RuleFor(a => a.Email)
                .NotEmpty()
                .WithMessage("Enter the User email!");

            RuleFor(a => a.Email)
                .EmailAddress()
                .When(a => !string.IsNullOrEmpty(a.Email))
                .WithMessage("Invalid email");
        }
    }
}
