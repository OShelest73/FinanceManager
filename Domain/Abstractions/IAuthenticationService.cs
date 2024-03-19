using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions;

public interface IAuthenticationService
{
    void Register(User user);

    string Authenticate(User user);

    string CreatePassword(string password, out byte[] passwordSalt);

    bool VerifyPasswordHash(string password, string passwordHash, byte[] passwordSalt);
}
