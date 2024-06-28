using APBD_Project.RequestModels;
using APBD_Project.Services;
using FluentValidation;

namespace APBD_Project.Endpoints;

public static class UsersEndpoints
{
    public static void RegisterUsersEndpoints(this RouteGroupBuilder builder)
    {
        var group = builder.MapGroup("/users");
        group.MapPost("/register", async (
            RegisterRequestModel model,
            IUserService service,
            IValidator<RegisterRequestModel> validator) =>
        {
            var validation = await validator.ValidateAsync(model);
            if (!validation.IsValid)
            {
                return Results.BadRequest("Problem with validation of RegisterRequestModel.");
            }
            
            try
            {
                await service.RegisterAsync(model);
                return Results.Created();
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }).AllowAnonymous();

        group.MapPost("/login", async (
            LoginRequestModel model,
            IUserService service) =>
        {
            try
            {
                var response = await service.LoginAsync(model);
                return Results.Ok(response);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }).AllowAnonymous();

        group.MapGet("/refreshToken/{refreshToken:string}", async (
            string refreshToken,
            IUserService service) =>
        {
            try
            {
                var response = await service.RefreshTokenAsync(refreshToken);
                return Results.Ok(response);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        });
    }
}