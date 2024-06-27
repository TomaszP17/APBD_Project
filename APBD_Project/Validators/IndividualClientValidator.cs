using APBD_Project.RequestModels;
using FluentValidation;

namespace APBD_Project.Validators;

public class IndividualClientValidator : AbstractValidator<CreateIndividualClientRequestModel>
{
    
    public IndividualClientValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MaximumLength(100);
        RuleFor(x => x.LastName)
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
            .Length(9);
        RuleFor(x => x.Pesel)
            .NotEmpty()
            .Length(11);
    }
    
}