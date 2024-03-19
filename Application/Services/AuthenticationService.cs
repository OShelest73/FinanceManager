using Application.Abstractions;
using Application.Authentication;
using Domain.Abstractions;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUserRepository _user;
    private readonly IJwtProvider _jwtProvider;

    public AuthenticationService(IUserRepository user, IJwtProvider jwtProvider)
    {
        _user = user;
        _jwtProvider = jwtProvider;
    }

    public void Register(User user)
    {
        string securePassword = CreatePassword(user.Password, out byte[] passwordSalt);

        user.Password = securePassword;
        user.Salt = passwordSalt;

        _user.CreateUser(user);
    }

    public string Authenticate(User user)
    {
        var token = _jwtProvider.Generate(user);

        return token;
    }

    public string CreatePassword(string password, out byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512())
        {
            passwordSalt = hmac.Key;
            byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            password = Encoding.UTF8.GetString(passwordHash);

            return password;
        }
    }

    public bool VerifyPasswordHash(string password, string passwordHash, byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512(passwordSalt))
        {
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            var translatedHash = Encoding.UTF8.GetString(computedHash);

            return translatedHash.Equals(passwordHash);
        }
    }
}
