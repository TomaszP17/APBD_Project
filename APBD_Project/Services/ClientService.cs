using APBD_Project.Contexts;
using APBD_Project.Models;
using APBD_Project.RequestModels;
using APBD_Project.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace APBD_Project.Services;

public class ClientService(DataBaseContext context) : IClientService
{
    public async Task CreateIndividualClientAsync(CreateIndividualClientRequestModel model)
    {
        var client = new IndividualClient
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Address = model.Address,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber,
            Pesel = model.Pesel
        };
        
        await context.IndividualClients.AddAsync(client);
        await context.SaveChangesAsync();
    }

    public async Task CreateCompanyClientAsync(CreateCompanyClientRequestModel model)
    {
        var client = new CompanyClient
        {
            CompanyName = model.Name,
            Address = model.Address,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber,
            KRSNumber = model.KRSNumber
        };
        
        await context.CompanyClients.AddAsync(client);
        await context.SaveChangesAsync();
    }

    public async Task DeleteIndividualClientAsync(int id)
    {
        var client = await context.IndividualClients.FirstOrDefaultAsync(x => x.ClientId == id);
        
        if (client == null)
        {
            throw new Exception("Client not found.");
        }

        client.IsDeleted = true;
        await context.SaveChangesAsync();
    }

    public async Task UpdateIndividualClientAsync(int id, CreateIndividualClientRequestModel model)
    {
        var client = await context.IndividualClients.FirstOrDefaultAsync(x => x.ClientId == id);
        
        if (client == null)
        {
            throw new Exception("Client not found.");
        }
        
        client.FirstName = model.FirstName;
        client.LastName = model.LastName;
        client.Address = model.Address;
        client.Email = model.Email;
        client.PhoneNumber = model.PhoneNumber;
        if (client.Pesel != model.Pesel)
        {
            throw new Exception("You can't change PESEL number.");
        }
        client.Pesel = model.Pesel;
        
        await context.SaveChangesAsync();
    }

    public async Task UpdateCompanyClientAsync(int id, CreateCompanyClientRequestModel model)
    {
        var client = await context.CompanyClients.FirstOrDefaultAsync(x => x.ClientId == id);
        
        if (client == null)
        {
            throw new Exception("Client not found.");
        }
        
        client.CompanyName = model.Name;
        client.Address = model.Address;
        client.Email = model.Email;
        client.PhoneNumber = model.PhoneNumber;
        if (client.KRSNumber != model.KRSNumber)
        {
            throw new Exception("You can't change KRS number.");
        }
        client.KRSNumber = model.KRSNumber;
        
        await context.SaveChangesAsync();
    }
}