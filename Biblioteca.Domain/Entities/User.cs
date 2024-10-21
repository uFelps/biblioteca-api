using System.ComponentModel.DataAnnotations;
using Biblioteca.Domain.Enuns;

namespace Biblioteca.Domain.Entities;

public class User
{
    public User()
    {
        
    }

    public User(int id, string name, string email, string password, UserRole role)
    {
        Id = id;
        Name = name;
        Email = email;
        Password = password;
        Role = role;
    }

    [Key]
    public int Id { get; set; }
    public string  Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public UserRole Role { get; set; }
}