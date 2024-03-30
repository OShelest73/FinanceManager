using Application.Dtos.UserDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.Controllers;
[Route("api/[controller]")]
[ApiController]
public class WalletController : ControllerBase
{
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
}
