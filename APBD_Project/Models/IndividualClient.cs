using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_Project.Models;

[Table("IndividualClients")]
public class IndividualClient : Client
{
    [Column("FirstName")]
    [MaxLength(100)]
    public string FirstName { get; set; }

    [Column("LastName")]
    [MaxLength(100)]
    public string LastName { get; set; }

    [Column("Pesel")]
    [MaxLength(11)]
    public string Pesel { get; set; }
    
    [Column("IsDeleted")]
    public bool IsDeleted { get; set; }
}
