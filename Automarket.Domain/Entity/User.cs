using System.ComponentModel.DataAnnotations;

namespace Automarket.Domain.Entity;

public class User
{
    [Key]
    public int? idUser { get; set; }
    
    public string Name { get; set; }
    
    public string Surname { get; set; }
    
    public string PhoneNumber { get; set; }
    
    public string Email { get; set; }
    
    public string Password { get; set; }
    
}