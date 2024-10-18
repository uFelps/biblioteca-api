using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Enuns;


namespace Biblioteca.Application.DTOs.User;

public class UserOutputDto
{
    public UserOutputDto()
    {
        
    }
    
    public UserOutputDto(Domain.Entities.User user)
    {
        Id = user.Id;
        Name = user.Name;
        Email = user.Email;
        Role = user.Role.ToString();
    }

    public int Id { get; set; }
    public string  Name { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
}