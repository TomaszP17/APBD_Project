using APBD_Project.RequestModels;
using APBD_Project.ResponseModels;

namespace APBD_Project.Services;

public interface IUserService
{
    Task RegisterAsync(RegisterRequestModel model);
    
    Task<LoginResponseModel> LoginAsync(LoginRequestModel model);
    
    Task<LoginResponseModel> RefreshTokenAsync(string refreshToken);
}