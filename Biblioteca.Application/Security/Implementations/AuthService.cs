using Biblioteca.Application.DTOs.User;
using Biblioteca.Application.Exceptions;
using Biblioteca.Application.Services.Interfaces;
using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Enuns;
using Biblioteca.Domain.Interfaces;

namespace Biblioteca.Application.Security.Implementations;

public class AuthService : IAuthService
{
    private readonly IUserRepository _repository;
    private readonly ITokenService _tokenService;
    private readonly IPasswordEncoder _passwordEncoder;

    public AuthService(IUserRepository repository, ITokenService tokenService, IPasswordEncoder passwordEncoder)
    {
        _repository = repository;
        _tokenService = tokenService;
        _passwordEncoder = passwordEncoder;
    }
    
    public async Task<TokenDto> SignUp(UserDto userDto, UserRole userRole)
    {
        var user = new User();
        user.Name = userDto.Name;
        user.Email = userDto.Email;
        user.Password = _passwordEncoder.HashPassword(userDto.Password);
        user.Role = userRole;

        var newuser = await _repository.PostUserAsync(user);

        var token = _tokenService.GenerateToken(newuser);
        return new TokenDto(newuser, token);
    }

    public async Task<TokenDto> Login(LoginDto loginDto)
    {
        var user = await _repository.GetUserByEmailAsync(loginDto.Email);

        if (user == null || !_passwordEncoder.VerifyPassword(loginDto.Password, user.Password))
        {
            throw new CredentialsNotValidException("Email or Password not valid");
        }

        var token = _tokenService.GenerateToken(user);
        return new TokenDto(user, token);
    }
}