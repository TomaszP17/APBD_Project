using APBD_Project.RequestModels;
using FluentValidation;

namespace APBD_Project.Validators;

public class CompanyClientValidator : AbstractValidator<CreateCompanyClientRequestModel>
{
    public CompanyClientValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);
        RuleFor(x => x.Address)
            .NotEmpty()
            .MaximumLength(100);
        RuleFor(x => x.Email)
            .NotEmpty()
            .MaximumLength(100);
        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .MaximumLength(9);
        RuleFor(x => x.KRSNumber)
            .NotEmpty()
            .MaximumLength(14);
    }
}