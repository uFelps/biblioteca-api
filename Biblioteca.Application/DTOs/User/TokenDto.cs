using Biblioteca.Domain.Entities;
namespace Biblioteca.Application.DTOs.User;

public class TokenDto
{
    public TokenDto()
    {
    }

    public TokenDto(int id, string name, string email, string role, string token)
    {
        Id = id;
        Name = name;
        Email = email;
        Role = role;
        Token = token;
    }

    public TokenDto(Domain.Entities.User user, string token)
    {
        Id = user.Id;
        Name = user.Name;
        Email = user.Email;
        Role = user.Role.ToString();
        Token = token;
    }
    

    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public string Token { get; set; }
}