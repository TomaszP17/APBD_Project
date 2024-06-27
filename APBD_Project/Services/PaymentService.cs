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
        
        if (contract.IsSigned)
        {
            throw new Exception("Contract is already signed.");
        }
        
        var payment = new Payment
        {
            Date = model.PaymentDate,
            PaymentAmount = model.PaymentAmount,
            ContractId = model.ContractId
        };
    }
}