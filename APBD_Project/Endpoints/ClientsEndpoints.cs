using APBD_Project.Exceptions;
using APBD_Project.RequestModels;
using APBD_Project.Services;
using FluentValidation;

namespace APBD_Project.Endpoints;

public static class ClientsEndpoints
{
    public static void RegisterClientsEndpoints(this RouteGroupBuilder builder)
    {
        var group = builder.MapGroup("/clients");

        group.MapPost("/individualClient", async (
            CreateIndividualClientRequestModel model,
            IClientService service,
            IValidator<CreateIndividualClientRequestModel> validator) =>
        {

            var validation = await validator.ValidateAsync(model);
            if (!validation.IsValid)
            {
                return Results.BadRequest("Problem with validation of IndividualClient.");
            }
            
            try
            {
                await service.CreateIndividualClientAsync(model);
                return Results.Created();
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
            
        }).RequireAuthorization("User");
        
        group.MapPost("/companyClient", async (
            CreateCompanyClientRequestModel model,
            IClientService service,
            IValidator<CreateCompanyClientRequestModel> validator) =>
        {
            var validation = await validator.ValidateAsync(model);
            if (!validation.IsValid)
            {
                return Results.BadRequest("Problem with validation of CompanyClient.");
            }
            
            try
            {
                await service.CreateCompanyClientAsync(model);
                return Results.Created();
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }).RequireAuthorization("User");
        
        group.MapDelete("/individualClient/{id:int}", async (
            int id,
            IClientService service) =>
        {
            try
            {
                await service.DeleteIndividualClientAsync(id);
                return Results.NoContent();
            }
            catch (ClientDoesNotExistsException e)
            {
                return Results.BadRequest(e.Message);
            }
        }).RequireAuthorization("Admin");
        
        group.MapPut("/individualClient/{id:int}", async (
            int id,
            CreateIndividualClientRequestModel model,
            IClientService service,
            IValidator<CreateIndividualClientRequestModel> validator) =>
        {
            
            var validation = await validator.ValidateAsync(model);
            
            if (!validation.IsValid)
            {
                return Results.BadRequest("Problem with validation of IndividualClient.");
            }
            
            try
            {
                await service.UpdateIndividualClientAsync(id, model);
                return Results.NoContent();
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }).RequireAuthorization("User");
        
        group.MapPut("/companyClient/{id:int}", async (
            int id,
            CreateCompanyClientRequestModel model,
            IClientService service,
            IValidator<CreateCompanyClientRequestModel> validator) =>
        {
            var validation = await validator.ValidateAsync(model);
            
            if (!validation.IsValid)
            {
                return Results.BadRequest("Problem with validation of CompanyClient.");
            }
            
            try
            {
                await service.UpdateCompanyClientAsync(id, model);
                return Results.NoContent();
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        });
    }
}