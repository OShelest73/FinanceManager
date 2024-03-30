using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories;

public class FinancialGoalRepository : BaseRepository<FinancialGoal>
{
    private readonly ApplicationDbContext _dbContext;

    public FinancialGoalRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<FinancialGoal>> GetUsersGoalsAsync(int userId)
    {
        var result = await _dbContext.Goals
            .Where(fg => fg.UserId == userId)
            .ToListAsync();

        return result;
    }
}
