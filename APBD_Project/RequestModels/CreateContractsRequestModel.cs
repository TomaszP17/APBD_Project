namespace APBD_Project.RequestModels;

public class CreateContractsRequestModel
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int SupportYears { get; set; }
    public int SoftwareId { get; set; }
    public int ClientId { get; set; }
}