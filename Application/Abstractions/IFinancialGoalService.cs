using Application.Dtos.FinancialGoalDtos;

namespace Application.Abstractions;
public interface IFinancialGoalService
{
    Task<List<FinancialGoalDto>> GetUserFinancialGoals(int userId);

    Task CreateFinancialGoal(CreateFinancialGoalDto goalDto);
}