using Biblioteca.Application.DTOs.User;
using Biblioteca.Application.Exceptions;
using Biblioteca.Application.Services.Interfaces;
using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Enuns;
using Biblioteca.Domain.Interfaces;

namespace Biblioteca.Application.Services.Implementations;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<UserOutputDto>> GetAllUsersAsync()
    {
        var users = await _repository.GetAllUsersAsync();

        var usersDto = users.Select(x => new UserOutputDto(x)).ToList();

        return usersDto;
    }

    public async Task<User> GetUserByIdAsync(int id)
    {
        var user = await _repository.GetUserByIdAsync(id);

        if (user == null)
        {
            throw new DataNotFoundException($"User not found. ID={id}");
        }

        return user;
    }

    public async Task<UserOutputDto> GetUserDtoByIdAsync(int id)
    {
        var user = await _repository.GetUserByIdAsync(id);

        if (user == null)
        {
            throw new DataNotFoundException($"User not found. ID={id}");
        }
        
        var userDto = new UserOutputDto(user);
        
        return userDto;
    }
    
    public async Task<UserOutputDto> UpdateUserAsync(int id, UserDto model)
    {
        var user = await _repository.GetUserByIdAsync(id);

        if (user == null)
        {
            throw new DataNotFoundException($"User not found. ID={id}");
        }

        user.Name = model.Name;
        user.Email = model.Email;
        user.Password = model.Password;

        await _repository.UpdateUserAsync(user);

        var userOutput = new UserOutputDto(user);

        return userOutput;
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        var user = await _repository.GetUserByIdAsync(id);

        if (user == null)
        {
            throw new DataNotFoundException($"User not found. ID={id}");
        }
        
        _repository.DeleteUser(user);

        return true;
    }
}