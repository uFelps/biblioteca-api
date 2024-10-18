using Biblioteca.Application.DTOs.User;

namespace Biblioteca.Application.Services.Interfaces;

public interface IUserService
{
    Task<List<UserOutputDto>> GetAllUsersAsync();
    Task<UserOutputDto?> GetUserByIdAsync(int id);
    Task<UserOutputDto> PostUserAsync(UserDto model);
    Task<UserOutputDto> PostUserAdminAsync(UserDto model);
    Task<UserOutputDto> UpdateUserAsync(int id, UserDto model);
    Task<bool> DeleteUserAsync(int id);
}