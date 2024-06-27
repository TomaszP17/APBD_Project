using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_Project.Models;

[Table("Contracts")]
public class Contract
{
    [Key]
    [Column("ContractId")]
    public int ContractId { get; set; }

    [Column("StartDate")]
    public DateTime StartDate { get; set; }
    
    [Column("EndDate")]
    public DateTime EndDate { get; set; }
    
    [Column("IsSigned")]
    public bool IsSigned { get; set; }
    
    [Column("CurrentlyPaid")]
    public double CurrentlyPaid { get; set; }
    
    [Column("TotalPaid")]
    public double TotalPaid { get; set; }
    
    [Column("ActualVersion")]
    public string ActualVersion { get; set; }
    
    [Column("SupportYears")] 
    public int SupportYears { get; set; }
    
    [ForeignKey("Software")]
    public int SoftwareId { get; set; }
    
    [ForeignKey("Client")]
    public int ClientId { get; set; }

    public Software Software { get; set; }
    public Client Client { get; set; }
    public IEnumerable<Payment> Payment { get; set; }
}