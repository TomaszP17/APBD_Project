using APBD_Project.RequestModels;
using APBD_Project.Validators;

namespace APBD_Project.Services;

public interface IClientService
{
    Task CreateIndividualClientAsync(CreateIndividualClientRequestModel model);
    Task CreateCompanyClientAsync(CreateCompanyClientRequestModel model);
    Task DeleteIndividualClientAsync(int id);
    Task UpdateIndividualClientAsync(int id, CreateIndividualClientRequestModel model);
    Task UpdateCompanyClientAsync(int id, CreateCompanyClientRequestModel model);
}