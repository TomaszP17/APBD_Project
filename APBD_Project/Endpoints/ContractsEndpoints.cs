using APBD_Project.RequestModels;
using APBD_Project.Services;
using FluentValidation;

namespace APBD_Project.Endpoints;

public static class ContractsEndpoints
{
    public static void RegisterContractsEndpoints(this RouteGroupBuilder builder)
    {
        var group = builder.MapGroup("/contracts");

        group.MapPost("/", async (
            CreateContractsRequestModel model,
            IContractService service,
            IValidator<CreateContractsRequestModel> validator) =>
        {
            var validation = await validator.ValidateAsync(model);
            
            if (!validation.IsValid)
            {
                return Results.BadRequest("Problem with validation of Contract.");
            }
            
            try
            {
                await service.CreateContractAsync(model);
                return Results.Created();
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }).RequireAuthorization("User");
        group.MapDelete("/{id:int}", async (
            int id,
            IContractService service) =>
        {
            try
            {
                await service.DeleteContractAsync(id);
                return Results.NoContent();
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }).RequireAuthorization("User");
    }
}