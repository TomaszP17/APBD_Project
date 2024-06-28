using APBD_Project.RequestModels;

namespace APBD_Project.Services;

public interface IClientService
{
    Task CreateIndividualClientAsync(CreateIndividualClientRequestModel model);
    Task CreateCompanyClientAsync(CreateCompanyClientRequestModel model);
    Task DeleteIndividualClientAsync(int id);
    Task UpdateIndividualClientAsync(int id, CreateIndividualClientRequestModel model);
    Task UpdateCompanyClientAsync(int id, CreateCompanyClientRequestModel model);
}