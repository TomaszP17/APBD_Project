using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_Project.Models;

[Table("Clients")]
public abstract class Client
{
    [Key]
    [Column("ClientId")]
    public int ClientId { get; set; }

    [Column("Address")]
    [MaxLength(100)]
    public string Address { get; set; }

    [Column("Email")]
    [MaxLength(100)]
    public string Email { get; set; }

    [Column("PhoneNumber")]
    [MaxLength(9)]
    public string PhoneNumber { get; set; }
}