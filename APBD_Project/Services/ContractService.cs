using APBD_Project.Contexts;
using APBD_Project.Models;
using APBD_Project.RequestModels;
using Microsoft.EntityFrameworkCore;

namespace APBD_Project.Services;

public class ContractService(DataBaseContext context) : IContractService
{
    public async Task CreateContractAsync(CreateContractsRequestModel model)
    {
        var client = await context.Clients.FirstOrDefaultAsync(c => c.ClientId == model.ClientId);
        var software = await context.Softwares.FirstOrDefaultAsync(s => s.SoftwareId == model.SoftwareId);
        
        if (client == null || software == null)
        {
            throw new Exception("Client or software not found");
        }

        var contract = await context.Contracts
            .FirstOrDefaultAsync(c => c.ClientId == model.ClientId && c.SoftwareId == model.SoftwareId && c.IsSigned == true);
        
        if(contract != null)
        {
            throw new Exception("Contract already exists and is signed for this product");
        }
        
        var bestDiscount = await context.Discounts
            .Where(d => d.SoftwareId == model.SoftwareId && d.StartDate <= DateTime.Now && d.EndDate >= DateTime.Now)
            .OrderByDescending(d => d.Percentage)
            .FirstOrDefaultAsync();

        var discount = bestDiscount?.Percentage ?? 0;
        
        var previousContracts = await context.Contracts
            .Where(c => c.ClientId == model.ClientId && c.IsSigned == true)
            .ToListAsync();

        if (previousContracts.Count > 0)
        {
            discount += 5;
        }
        
        var basePrice = software.BuyPrice;
        var costOfSupport = model.SupportYears * 1000;
        var totalBasePrice = basePrice + costOfSupport;
        var discountedPrice = totalBasePrice - (totalBasePrice * discount / 100);
        
        if ((model.EndDate - model.StartDate).TotalDays < 3 || (model.EndDate - model.StartDate).TotalDays > 30)
        {
            throw new Exception("Contract duration must be between 3 and 30 days");
        }
        
        var newContract = new Contract
        {
            StartDate = model.StartDate,
            EndDate = model.EndDate,
            TotalPaid = discountedPrice,
            SupportYears = model.SupportYears,
            SoftwareId = model.SoftwareId,
            ClientId = model.ClientId,
            IsSigned = false,
            CurrentlyPaid = 0,
            ActualVersion = software.ActualVersion
        };
            
        await context.Contracts.AddAsync(newContract);
        await context.SaveChangesAsync();
    }

    public async Task DeleteContractAsync(int id)
    {
        var contract = await context.Contracts.FirstOrDefaultAsync(c => c.ContractId == id);
        
        if (contract == null)
        {
            throw new Exception("Contract not found.");
        }
        
        context.Contracts.Remove(contract);
        await context.SaveChangesAsync();
    }
}