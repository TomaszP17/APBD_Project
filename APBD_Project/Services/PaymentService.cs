using APBD_Project.Contexts;
using APBD_Project.Models;
using APBD_Project.RequestModels;
using Microsoft.EntityFrameworkCore;

namespace APBD_Project.Services;

public class PaymentService(DataBaseContext context) : IPaymentService
{
    public async Task CreatePaymentAsync(CreatePaymentRequestModel model)
    {
        var client = await context.Clients.FirstOrDefaultAsync(x => x.ClientId == model.ClientId);
        var contract = await context.Contracts.FirstOrDefaultAsync(x => x.ContractId == model.ContractId);
        
        if (client == null || contract == null)
        {
            throw new Exception("Client or contract not found.");
        }
        
        if (contract.ClientId != client.ClientId)
        {
            throw new Exception("Client and contract do not match.");
        }
        
        if(contract.EndDate < DateTime.Now)
        {
            throw new Exception("Contract has already ended.");
        }
        
        if (contract.IsSigned)
        {
            throw new Exception("Contract is already signed.");
        }
        
        var payment = new Payment
        {
            Amount = model.Amount,
            Date = DateTime.Now,
            ContractId = model.ContractId,
            ClientId = model.ClientId
        };
        
        await context.Payments.AddAsync(payment);

        var currentlyPaid = contract.CurrentlyPaid;
        var totalCost = contract.TotalPaid;
        
        if (currentlyPaid + model.Amount > totalCost)
        {
            throw new Exception("You try to pay more than you should.");
        }
        else if (currentlyPaid + model.Amount == totalCost)
        {
            contract.CurrentlyPaid += model.Amount;
            contract.IsSigned = true;
        }
        else
        {
            contract.CurrentlyPaid += model.Amount;
        }
        await context.SaveChangesAsync();
    }
}