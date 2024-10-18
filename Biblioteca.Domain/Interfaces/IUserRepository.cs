using Biblioteca.Domain.Entities;

namespace Biblioteca.Domain.Interfaces;

public interface IUserRepository
{
    Task<List<User>> GetAllUsersAsync();
    Task<User?> GetUserByIdAsync(int id);
    Task<User> PostUserAsync(User model);
    Task<User> UpdateUserAsync(User model);
    void DeleteUser(User model);
}