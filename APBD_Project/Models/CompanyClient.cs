using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_Project.Models;
[Table("CompanyClients")]
public class CompanyClient : Client
{
    [Column("CompanyName")]
    [MaxLength(100)]
    public string CompanyName { get; set; }

    [Column("KRSNumber")]
    [MaxLength(14)]
    public string KRSNumber { get; set; }
}
