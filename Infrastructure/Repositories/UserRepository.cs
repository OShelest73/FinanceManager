using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Domain.Abstractions;

namespace Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly DbSet<User> _user;

    public UserRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        _user = _dbContext.Set<User>();
    }

    public async Task<User> GetUserByIdAsync(int id)
    {
        var result = await _user.FirstOrDefaultAsync(u => u.Id == id);

        return result;
    }

    public async Task<User> GetUserByEmailAsync(string email)
    {
        var result = await _user.FirstOrDefaultAsync(u => u.Email == email);

        return result;
    }

    public async Task CreateUserAsync(User user)
    {
        await _user.AddAsync(user);
        await SaveAsync();
    }

    public async Task UpdateUserAsync(User user)
    {
        _user.Update(user);
        await SaveAsync();
    }

    public async Task<bool> IsEmailUniqueAsync(string email)
    {
        return !await _user.AnyAsync(u => u.Email == email);
    }

    public async Task SaveAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}
