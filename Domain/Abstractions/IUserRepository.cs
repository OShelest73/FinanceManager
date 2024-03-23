using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions;

public interface IUserRepository
{
    Task<User> GetUserByIdAsync(int id);

    Task<User> GetUserByEmailAsync(string email);

    Task CreateUserAsync(User user);

    Task UpdateUserAsync(User user);

    Task<bool> IsEmailUniqueAsync(string email);

    Task SaveAsync();
}
