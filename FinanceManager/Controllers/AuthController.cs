using Application.Dtos.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;

namespace FinanceManager.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> Register([FromBody] RegisterDto registerDto)
    {
        var command = new CreateUserCommand(registerDto);

        try
        {
            await _mediator.Send(command, cancellationToken);
        }
        catch (ValidationException ex)
        {
            var errors = ex.Errors.Select(error => new { error.PropertyName, error.ErrorMessage });
            return BadRequest(errors);
        }

        return Ok();
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody] AuthenticationRequest authenticationRequest, CancellationToken cancellationToken)
    {
        var command = new AuthenticateUserCommand(authenticationRequest);

        try
        {
            string token = await _mediator.Send(command, cancellationToken);

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
