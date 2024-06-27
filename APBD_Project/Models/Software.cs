using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_Project.Models;

[Table("Softwares")]
public class Software
{
    [Key]
    [Column("SoftwareId")]
    public int SoftwareId { get; set; }

    [Column("Name")]
    [MaxLength(100)]
    public string Name { get; set; }

    [Column("Description")]
    [MaxLength(200)]
    public string Description { get; set; }

    [Column("ActualVersion")]
    [MaxLength(50)]
    public string ActualVersion { get; set; }

    [Column("Category")]
    [MaxLength(50)]
    public string Category { get; set; }

    [Column("BuyPrice")]
    public double BuyPrice { get; set; }
    
    [Column("SubPrice")]
    public double SubPrice { get; set; }

    public IEnumerable<Discount> Discounts { get; set; }
    public IEnumerable<Contract> Contracts { get; set; }
}