using Domain.Entities;

namespace Domain.Abstractions;

public interface IFinancialGoalRepository : IBaseRepository<FinancialGoal>
{
    Task<FinancialGoal> GetGoalWihCategoryAsync(int goalId);

    Task<List<FinancialGoal>> GetUsersGoalsAsync(int userId);

    Task<List<FinancialGoal>> GetGoalsByCategoryAsync(int categoryId, DateTime dateTime, int userId);
}
