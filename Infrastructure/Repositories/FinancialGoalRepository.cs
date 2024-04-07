using Domain.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class FinancialGoalRepository : BaseRepository<FinancialGoal>, IFinancialGoalRepository
{
    private readonly ApplicationDbContext _dbContext;

    public FinancialGoalRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<FinancialGoal>> GetUsersGoalsAsync(int userId)
    {
        var result = await _dbContext.Goals
            .Include(fg => fg.Category)
            .Where(fg => fg.UserId == userId)
            .ToListAsync();

        return result;
    }
}
