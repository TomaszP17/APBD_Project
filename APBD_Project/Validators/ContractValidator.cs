using APBD_Project.RequestModels;
using FluentValidation;

namespace APBD_Project.Validators;

public class ContractValidator : AbstractValidator<CreateContractsRequestModel>
{
    public ContractValidator()
    {
        RuleFor(x => x.StartDate)
            .NotEmpty();
        RuleFor(x => x.EndDate)
            .NotEmpty();
        RuleFor(x => x.SupportYears)
            .GreaterThanOrEqualTo(0);
        RuleFor(x => x.SoftwareId)
            .NotEmpty();
        RuleFor(x => x.ClientId)
            .NotEmpty();
    }
}