using APBD_Project.RequestModels;

namespace APBD_Project.Services;

public interface IContractService
{
    Task CreateContractAsync(CreateContractsRequestModel model);
    Task DeleteContractAsync(int id);
}