using APBD_Project.RequestModels;
using FluentValidation;

namespace APBD_Project.Validators;

public class PaymentValidator : AbstractValidator<CreatePaymentRequestModel>
{
    public PaymentValidator()
    {
        RuleFor(x => x.ClientId).NotEmpty();
        RuleFor(x => x.ContractId).NotEmpty();
        RuleFor(x => x.Amount).GreaterThan(0);
    }
}