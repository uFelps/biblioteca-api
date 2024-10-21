using System.ComponentModel.DataAnnotations;
using Biblioteca.Domain.Enuns;
using Biblioteca.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Biblioteca.Application.DTOs.User;

public class UserDto
{
    public UserDto()
    {
    }

    public UserDto(int? id, string name, string email, string password, UserRole? role)
    {
        Id = id;
        Name = name;
        Email = email;
        Password = password;
        Role = role;
    }

    public int? Id { get; set; }
    
    [Required(ErrorMessage = "This field is required")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "This field is required")]
    [EmailAddress(ErrorMessage = "This field must be a email")]
    [EmailInUse]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "This field is required")]
    public string Password { get; set; }
    
    
    public UserRole? Role { get; set; }
    
    
}

public class EmailInUseAttribute : ValidationAttribute
{
    protected override  ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
      
        var context = (IUserRepository) validationContext.GetService(typeof(IUserRepository))!;
        var email = value.ToString();
        var user = context.GetUserByEmail(email);

        return user != null ? new ValidationResult("Email in use") : ValidationResult.Success;
    }
}