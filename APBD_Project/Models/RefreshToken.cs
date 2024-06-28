using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_Project.Models;

[Table("RefreshToken")]
public class RefreshToken
{
    [Key]
    [Column("Id")]
    public int Id { get; set; }
    
    [Column("Token")]
    public string Token { get; set; }
    
    [Column("ExpiryDate")]
    public DateTime? ExpiryDate { get; set; }
    
    [ForeignKey("User")]
    [Column("UserId")]
    public int UserId { get; set; }
    
    public User User { get; set; }
}