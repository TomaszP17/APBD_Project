using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using APBD_Project.Enums;

namespace APBD_Project.Models;

[Table("User")]
public class User
{
    [Key]
    [Column("IdUser")]
    public int IdUser { get; set; }
    
    [Column("Login")]
    [MaxLength(100)]
    public string Login { get; set; }
    
    [Column("Email")]
    [MaxLength(100)]
    public string Email { get; set; }
    
    [Column("Password")]
    [MaxLength(100)]
    public string Password { get; set; }
    
    [Column("Salt")]
    public string Salt { get; set; }
    
    [Column("RefreshToken")]
    public string RefreshToken { get; set; }
    
    [Column("RefreshTokenExp")]
    public DateTime? RefreshTokenExp { get; set; }
    
    [Column("Role")]
    public UserRoles UserRoles { get; set; }
}