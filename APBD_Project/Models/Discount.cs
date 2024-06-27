using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_Project.Models;

[Table("Discounts")]
public class Discount
{
    [Key]
    [Column("DiscountId")]
    public int DiscountId { get; set; }

    [Column("Name")]
    [MaxLength(100)]
    public string Name { get; set; }

    [Column("Percentage")]
    public double Percentage { get; set; }

    [Column("StartDate")]
    public DateTime StartDate { get; set; }

    [Column("EndDate")]
    public DateTime EndDate { get; set; }

    [ForeignKey("Software")]
    public int SoftwareId { get; set; }
    
    public Software Software { get; set; }
}