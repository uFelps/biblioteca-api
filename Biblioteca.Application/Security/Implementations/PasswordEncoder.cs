using Biblioteca.Application.Services.Interfaces;

namespace Biblioteca.Application.Security.Implementations;

public class PasswordEncoder : IPasswordEncoder
{
    public string HashPassword(string password)
    {
       return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool VerifyPassword(string password, string hashedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}