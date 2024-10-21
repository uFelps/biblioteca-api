using Biblioteca.Domain.Entities;

namespace Biblioteca.Domain.Interfaces;

public interface IUserRepository
{
    Task<List<User>> GetAllUsersAsync();
    Task<User?> GetUserByIdAsync(int id);
    Task<User?> GetUserByEmailAsync(string email);
    User? GetUserByEmail(string email);
    Task<User> PostUserAsync(User model);
    Task<User> UpdateUserAsync(User model);
    void DeleteUser(User model);
    
}