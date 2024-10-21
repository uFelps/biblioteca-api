using Biblioteca.Application.DTOs.User;
using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Enuns;

namespace Biblioteca.Application.Services.Interfaces;

public interface IAuthService
{

    Task<TokenDto> SignUp(UserDto userDto, UserRole userRole);
    Task<TokenDto> Login(LoginDto loginDto);
}