using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_Project.Models;

[Table("Payments")]
public class Payment
{
    [Key]
    [Column("PaymentId")]
    public int PaymentId { get; set; }
    
    [Column("Amount")]
    public double Amount { get; set; }
    
    [Column("Date")]
    public DateTime Date { get; set; }
    
    [ForeignKey("Contract")]
    [Column("ContractId")]
    public int ContractId { get; set; }
    
    [ForeignKey("Client")]
    [Column("ClientId")]
    public int ClientId { get; set; }
    
    public Contract Contract { get; set; }
    public Client Client { get; set; }
}