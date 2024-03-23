using Application.Dtos.User;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators;

public class AuthenticationRequestValidator : AbstractValidator<AuthenticationRequest>
{
    public AuthenticationRequestValidator()
    {
        RuleFor(a => a.Email).EmailAddress().WithMessage("Invalid email address");
        RuleFor(a => a.Password).NotEmpty().WithMessage("Password is required");
    }
}
