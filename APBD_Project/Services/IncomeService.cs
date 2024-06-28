using APBD_Project.Contexts;
using APBD_Project.ResponseModels;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace APBD_Project.Services;

public class IncomeService(DataBaseContext context, HttpClient client) : IIncomeService
{
    public async Task<GetIncomeCompanyResponseModel> GetIncomeCompanyAsync(string? currency)
    {
        currency = currency == null ? "PLN" : currency.ToUpper();
        
        var totalPaidFromContracts = context.Contracts
            .Where(c => c.IsSigned == true)
            .Select(c => c.TotalPaid)
            .Sum();

        var totalExpectedIncomeFromContracts = context.Contracts
            .Where(c => c.IsSigned == false && c.EndDate > DateTime.Now)
            .Select(c => c.TotalPaid)
            .Sum() + totalPaidFromContracts;
        
        if (currency != "PLN")
        {
            var exchangeRate = await GetCourseAsync(currency);
            totalPaidFromContracts *= exchangeRate;
            totalExpectedIncomeFromContracts *= exchangeRate;
        }
        
        return new GetIncomeCompanyResponseModel()
        {
            RealIncome = Math.Round(totalPaidFromContracts, 2),
            ExpectedIncome = Math.Round(totalExpectedIncomeFromContracts, 2)
        };

    }

    public async Task<GetIncomeProductResponseModel> GetIncomeProductAsync(string? currency, int productId)
    {
        currency = currency == null ? "PLN" : currency.ToUpper();
        var product = await context.Softwares.FirstOrDefaultAsync(s => s.SoftwareId == productId);
        
        if (product == null)
        {
            throw new Exception("Product not found.");
        }

        var totalPaidFromContracts = context.Contracts
            .Where(c => c.IsSigned == true && c.SoftwareId == productId)
            .Select(c => c.TotalPaid)
            .Sum();

        var totalExpectedIncomeFromContracts = context.Contracts
            .Where(c => c.IsSigned == false && c.EndDate > DateTime.Now && c.SoftwareId == productId)
            .Select(c => c.TotalPaid)
            .Sum() + totalPaidFromContracts;
        
        
        if (currency != "PLN")
        {
            var exchangeRate = await GetCourseAsync(currency);
            totalPaidFromContracts *= exchangeRate;
            totalExpectedIncomeFromContracts *= exchangeRate;
        }
        
        return new GetIncomeProductResponseModel
        {
            ProductId = productId,
            RealIncome = Math.Round(totalPaidFromContracts, 2),
            ExpectedIncome = Math.Round(totalExpectedIncomeFromContracts, 2)
        };
    }
    private async Task<double> GetCourseAsync(string currency)
    {
        var apiResponse = await client.GetStringAsync($"https://v6.exchangerate-api.com/v6/0a7291e6f696b7c94c7c18ac/latest/PLN");
        
        var exchangesRates = JObject.Parse(apiResponse)["conversion_rates"];
        
        var rate = exchangesRates.Value<double>(currency);
        
        if (rate == 0)
        {
            throw new Exception("Currency with that code is not exists.");
        }
        return rate;
    }
}