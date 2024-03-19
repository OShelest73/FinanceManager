using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Application.Abstractions;
using System.Linq;

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

    public User GetUser(Func<User, bool> predicate)
    {
        var result = _user.FirstOrDefault(predicate);

        return result;
    }

    public void CreateUser(User user)
    {
        _user.Add(user);
        Save();
    }

    public void UpdateUser(Func<User, bool> predicate)
    {
        var result = GetUser(predicate);

        _user.Update(result);
        Save();
    }

    public void Save()
    {
        _dbContext.SaveChanges();
    }
}
