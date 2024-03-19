using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions;

public interface IUserRepository
{
    User GetUser(Func<User, bool> predicate);

    void CreateUser(User user);

    void UpdateUser(Func<User, bool> predicate);

    void Save();
}
