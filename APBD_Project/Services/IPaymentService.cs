using APBD_Project.RequestModels;

namespace APBD_Project.Services;

public interface IPaymentService
{
    Task CreatePaymentAsync(CreatePaymentRequestModel model);
}