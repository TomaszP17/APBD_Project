namespace APBD_Project.ResponseModels;

public class GetIncomeProductResponseModel
{
    public int ProductId { get; set; }
    public double RealIncome { get; set; }
    public double ExpectedIncome { get; set; }
}