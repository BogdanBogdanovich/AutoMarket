using System.ComponentModel.DataAnnotations;

namespace Automarket.Domain.ViewModels.User;

public class UserViewModel
{
    public string Name { get; set; }
    
    public string Surname { get; set; }
    
    public string PhoneNumber { get; set; }
    
    [Required(ErrorMessage ="Не указан Email")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "Не указан пароль")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}