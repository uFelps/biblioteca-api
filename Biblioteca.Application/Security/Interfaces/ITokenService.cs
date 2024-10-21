using Biblioteca.Domain.Entities;

namespace Biblioteca.Application.Services.Interfaces;

public interface ITokenService
{
    string GenerateToken(User user);
}