using Biblioteca.Domain.Entities;

namespace Biblioteca.Application.Security.Interfaces;

public interface ITokenService
{
    string GenerateToken(User user);
    int GetIdFromUser(string token);
}