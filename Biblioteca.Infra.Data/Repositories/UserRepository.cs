using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;
using Biblioteca.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infra.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DataContext _dbContext;

    public UserRepository(DataContext context)
    {
        _dbContext = context;
    }
    
    public async Task<List<User>> GetAllUsersAsync()
    {
        var users = await _dbContext.Users.AsNoTracking().ToListAsync();

        return users;
    }

    public async Task<User?> GetUserByIdAsync(int id)
    {
        var user = await _dbContext
            .Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        return user;
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        var user = await _dbContext
            .Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Email == email);

        return user;
    }

    public User? GetUserByEmail(string email)
    {
        var user = _dbContext
            .Users
            .AsNoTracking()
            .FirstOrDefault(x => x.Email == email);

        return user;
    }


    public async Task<User> PostUserAsync(User model)
    { 
        _dbContext.Users.Add(model);
        await _dbContext.SaveChangesAsync();
        return model;
    }

    public async Task<User> UpdateUserAsync(User model)
    {
        _dbContext.Users.Update(model);
        await _dbContext.SaveChangesAsync();
        return model;
    }

    public async void DeleteUser(User model)
    {
        _dbContext.Users.Remove(model);
        await _dbContext.SaveChangesAsync();
    }
}