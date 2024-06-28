using APBD_Project.RequestModels;
using APBD_Project.Services;
using FluentValidation;

namespace APBD_Project.Endpoints;

public static class IncomesEndpoints
{
    public static void RegisterIncomesEndpoints(this RouteGroupBuilder builder)
    {
        var group = builder.MapGroup("/incomes");
        
        group.MapGet("/", async (
            string? currency,
            IIncomeService service) =>
        {
            try
            {
                var incomes = await service.GetIncomeCompanyAsync(currency);
                return Results.Ok(incomes);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        });

        group.MapGet("/{productId:int}", async (
            string? currency,
            int productId,
            IIncomeService service) =>
        {
            try
            {
                var incomes = await service.GetIncomeProductAsync(currency, productId);
                return Results.Ok(incomes);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        });

    }
}