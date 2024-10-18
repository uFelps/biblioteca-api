using System.ComponentModel.DataAnnotations;
using Biblioteca.Domain.Enuns;

namespace Biblioteca.Application.DTOs.User;

public class UserDto
{
    public int? Id { get; set; }
    
    [Required(ErrorMessage = "This field is required")]
    public string  Name { get; set; }
    
    [Required(ErrorMessage = "This field is required")]
    [EmailAddress(ErrorMessage = "This field must be a email")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "This field is required")]
    public string Password { get; set; }
    
    
    public UserRole? Role { get; set; }
}