using Biblioteca.Application.DTOs.User;
using Biblioteca.Domain.Entities;

namespace Biblioteca.Application.Services.Interfaces;

public interface IUserService
{
    Task<List<UserOutputDto>> GetAllUsersAsync();
    Task<UserOutputDto> GetUserDtoByIdAsync(int id);
    Task<User> GetUserByIdAsync(int id);
    Task<UserOutputDto> UpdateUserAsync(int id, UserDto model);
    Task<bool> DeleteUserAsync(int id);
}