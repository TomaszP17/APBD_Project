using APBD_Project.RequestModels;
using APBD_Project.Services;
using FluentValidation;

namespace APBD_Project.Endpoints;

public static class PaymentsEndpoints
{
    public static void RegisterPaymentsEndpoints(this RouteGroupBuilder builder)
    {
        var group = builder.MapGroup("/payments");

        group.MapPost("/", async (
            CreatePaymentRequestModel model,
            IPaymentService service,
            IValidator<CreatePaymentRequestModel> validator) =>
        {
            var validation = await validator.ValidateAsync(model);
            
            if (!validation.IsValid)
            {
                return Results.BadRequest("Problem with validation of Contract.");
            }

            try
            {
                await service.CreatePaymentAsync(model);
                return Results.Created();
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
            
        });
    }
}