using CRUDUserFeature.Commands;
using FluentValidation;

namespace CRUDUserFeature.Validators
{
    public class CreateUserDtoValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.BirthDay).LessThan(DateTime.Now);
        }
    }
}
