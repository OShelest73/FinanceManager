using Domain.Entities;

namespace Domain.Abstractions;

public interface IFinancialGoalRepository : IBaseRepository<FinancialGoal>
{
    Task<List<FinancialGoal>> GetUsersGoalsAsync(int userId);
}
