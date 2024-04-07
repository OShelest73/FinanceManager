using Application.Abstractions;
using Application.Dtos.FinancialGoalDtos;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.Controllers;
[Route("api/[controller]")]
[ApiController]
public class FinancialGoalController : ControllerBase
{
    private readonly IFinancialGoalService _goalService;

    public FinancialGoalController(IFinancialGoalService goalService)
    {
        _goalService = goalService;
    }

    [HttpGet]
    public async Task<ActionResult> GetUserFinancialGoals(int userId)
    {
        var goals = await _goalService.GetUserFinancialGoals(userId);

        return Ok(goals);
    }

    [HttpPost]
    public async Task<ActionResult> CreateFinancialGoal(CreateFinancialGoalDto goalDto)
    {
        await _goalService.CreateFinancialGoal(goalDto);

        return Ok();
    }
}
