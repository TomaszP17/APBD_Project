using APBD_Project.Contexts;
using APBD_Project.Enums;
using APBD_Project.Helpers;
using APBD_Project.Models;
using APBD_Project.RequestModels;
using APBD_Project.ResponseModels;
using Microsoft.EntityFrameworkCore;

namespace APBD_Project.Services;

public class UserService(DataBaseContext context, IConfiguration configuration) : IUserService
{
    public async Task RegisterAsync(RegisterRequestModel model)
    {
        var hashedPasswordAndSalt = SecurityHelpers.GetHashedPasswordAndSalt(model.Password);

        var user = new User()
        {
            Login = model.Login,
            Email = model.Email,
            Password = hashedPasswordAndSalt.Item1,
            Salt = hashedPasswordAndSalt.Item2,
            RefreshToken = SecurityHelpers.GenerateRefreshToken(),
            RefreshTokenExp = DateTime.Now.AddDays(1),
            UserRoles = UserRoles.User
        };

        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
    }

    public async Task<LoginResponseModel> LoginAsync(LoginRequestModel model)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.Login == model.Login);
        if (user is null || !SecurityHelpers.CheckIfPasswordIsCorrect(user.Password, model.Password, user.Salt))
        {
            return null;
        }
        
        var token = SecurityHelpers.GenerateJwtToken(user, configuration);
        var refreshToken = SecurityHelpers.GenerateRefreshToken();
            
        context.RefreshTokens.Add(new RefreshToken
        {
            Token = refreshToken,
            ExpiryDate = DateTime.Now.AddDays(3),
            UserId = user.IdUser
        });
        await context.SaveChangesAsync();

        return new LoginResponseModel
        {
            Token = token,
            RefreshToken = refreshToken
        };
    }
    public async Task<LoginResponseModel> RefreshTokenAsync(string refreshToken)
    {
        var storedToken = await context.RefreshTokens.Include(rt => rt.User)
            .SingleOrDefaultAsync(rt => rt.Token == refreshToken);

        if (storedToken == null || storedToken.ExpiryDate <= DateTime.Now) return null;

        var user = storedToken.User;
        var newJwtToken = SecurityHelpers.GenerateJwtToken(user, configuration);
        var newRefreshToken = SecurityHelpers.GenerateRefreshToken();

        storedToken.Token = newRefreshToken;
        storedToken.ExpiryDate = DateTime.Now.AddDays(3);
        context.RefreshTokens.Update(storedToken);
        await context.SaveChangesAsync();

        return new LoginResponseModel
        {
            Token = newJwtToken,
            RefreshToken = newRefreshToken
        };
    }
}