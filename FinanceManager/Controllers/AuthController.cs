using Application.Abstractions;
using Application.Dtos.User;
using Application.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;

namespace FinanceManager.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<ActionResult> Register([FromBody] RegisterDto registerDto)
    {
        try
        {
            await _userService.RegisterAsync(registerDto);
        }
        catch (ValidationException ex)
        {
            var errors = ex.Errors.Select(error => new { error.PropertyName, error.ErrorMessage });
            return BadRequest(errors);
        }

        return Ok();
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody] AuthenticationRequest authenticationRequest)
    {
        try
        {
            string token = _userService.Authenticate(authenticationRequest);

            return Ok(token);
        }
        catch (ValidationException validationEx)
        {
            var errors = validationEx.Errors.Select(error => new { error.PropertyName, error.ErrorMessage });
            return BadRequest(errors);
        }
        catch (InvalidCredentialsException credentialsEx)
        {
            return Unauthorized(credentialsEx.Message);
        }
    }
}
