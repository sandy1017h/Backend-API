using server.Utils;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Entities;

public class User
{
    [Key]
    public int UserId { get; set; }
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    public string Role { get; set; }
    public string Address { get; set; } = "";

    public string RefreshToken { get; set; }

    public DateTime RefreshTokenExpire { get; set; }

    [Column(TypeName = "nvarchar(20)")]
    public string PhoneNumber { get; set; }
    
    
    public string BusinessName { get; set; }

    
    public BusinessTypes BusinessType { get; set; }

    
    public string GSTNumber { get; set; }
}
