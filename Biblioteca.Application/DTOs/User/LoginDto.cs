using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Application.DTOs.User;

public class LoginDto
{
    public LoginDto()
    {
    }

    public LoginDto(string email, string password)
    {
        Email = email;
        Password = password;
    }


    [Required(ErrorMessage = "This field is required")]
    [EmailAddress(ErrorMessage = "This field must be a email")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "This field is required")]
    public string Password { get; set; }
}