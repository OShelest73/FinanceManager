using Application.Dtos.User;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions;

public interface IUserService
{
    Task RegisterAsync(RegisterDto userToRegistrate);

    Task<string> Authenticate(AuthenticationRequest request);

    string CreatePassword(string password, out byte[] passwordSalt);

    bool VerifyPasswordHash(string password, string passwordHash, byte[] passwordSalt);
}
