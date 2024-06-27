namespace APBD_Project.RequestModels;

public class CreatePaymentRequestModel
{
    public int ClientId { get; set; }
    public int ContractId { get; set; }
    public double Amount { get; set; }
}