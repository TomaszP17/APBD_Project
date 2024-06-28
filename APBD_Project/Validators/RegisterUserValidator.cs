using APBD_Project.RequestModels;
using FluentValidation;

namespace APBD_Project.Validators;

public class RegisterUserValidator : AbstractValidator<RegisterRequestModel>
{
    public RegisterUserValidator()
    {
        RuleFor(x => x.Login)
            .NotEmpty()
            .MaximumLength(100);
        
        RuleFor(x => x.Password)
            .NotEmpty()
            .MaximumLength(100);
        RuleFor(x => x.Email)
            .NotEmpty()
            .MaximumLength(100);
    }
}