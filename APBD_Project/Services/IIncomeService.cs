using APBD_Project.ResponseModels;

namespace APBD_Project.Services;

public interface IIncomeService
{
    Task<GetIncomeCompanyResponseModel> GetIncomeCompanyAsync(string currency);
    Task<GetIncomeProductResponseModel> GetIncomeProductAsync(string currency, int productId);
}