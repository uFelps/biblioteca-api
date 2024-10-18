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

    public async Task<UserOutputDto?> GetUserByIdAsync(int id)
    {
        var user = await _repository.GetUserByIdAsync(id);

        if (user == null)
        {
            return null;
        }
        
        var userDto = new UserOutputDto(user);
        
        return userDto;
    }

    public async Task<UserOutputDto> PostUserAsync(UserDto model)
    {
        var user = new User();
        user.Name = model.Name;
        user.Email = model.Email;
        user.Password = model.Password;
        user.Role = UserRole.READER;

        var userDto = new UserOutputDto(await _repository.PostUserAsync(user));


        return userDto;
    }

    public async Task<UserOutputDto> PostUserAdminAsync(UserDto model)
    {
        var user = new User();
        user.Name = model.Name;
        user.Email = model.Email;
        user.Password = model.Password;
        user.Role = UserRole.ADMIN;

    

        var userDto = new UserOutputDto(await _repository.PostUserAsync(user));


        return userDto;
    }

    public async Task<UserOutputDto> UpdateUserAsync(int id, UserDto model)
    {
        var user = _repository.GetUserByIdAsync(id).Result;

        if (user == null)
        {
            throw new UserNotFoundException($"User not found. ID={id}");
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
            throw new UserNotFoundException($"User not found. ID={id}");
        }
        
        _repository.DeleteUser(user);

        return true;
    }
}