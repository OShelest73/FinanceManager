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

    [HttpGet("get-detailed")]
    public async Task<ActionResult> GetFinancialGoalDetailed(int goalId, int userId)
    {
        var goal = await _goalService.GetGoalDetailedAsync(goalId, userId);

        return Ok(goal);
    }

    [HttpPost]
    public async Task<ActionResult> CreateFinancialGoal(CreateFinancialGoalDto goalDto)
    {
        await _goalService.CreateFinancialGoal(goalDto);

        return Ok();
    }

    [HttpPut]
    public async Task<ActionResult> CreateFinancialGoal(UpdateFinancialGoalDto goalDto)
    {
        await _goalService.UpdateFinancialGoal(goalDto);

        return Ok();
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteFinancialGoal(int goalId)
    {
        await _goalService.DeleteFinancialGoal(goalId);

        return Ok();
    }
}
