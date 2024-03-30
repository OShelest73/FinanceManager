using Domain.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class MoneyTransactionRepository : BaseRepository<MoneyTransaction>, IMoneyTransactionRepository
{
    private readonly ApplicationDbContext _dbContext;

    public MoneyTransactionRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<MoneyTransaction>> GetUserTransactionsByCategoryAsync(int userId, int categoryId)
    {
        var result = await _dbContext.Transactions
            .Where(mt => mt.UserId == userId && mt.CategoryId == categoryId)
            .ToListAsync();

        return result;
    }

    public override async Task<MoneyTransaction> GetByIdAsync(int id)
    {
        var result = await _dbContext.Transactions
            .Include(mt => mt.Category)
            .Include(mt => mt.Wallet)
            .FirstOrDefaultAsync(mt => mt.Id == id);

        return result;
    }

    public async Task<decimal> CalculateTotalAsync(Category category, int userId)
    {
        decimal total = 0;
        total = await _dbContext.Transactions
            .Where(t => t.Category == category && t.UserId == userId &&
            t.CreatedAt >= DateTime.Now.AddMonths(-1) && t.CreatedAt <= DateTime.Now)
            .SumAsync(t => t.Amount);

        return total;
    }

    public async Task<decimal> CalculateTotalIncomeAsync(Category category, int userId, DateTime leftBound, DateTime rightBound)
    {
        decimal total = 0;
        total = await _dbContext.Transactions
            .Where(t => t.Category == category && t.Amount > 0 && t.UserId == userId
            && t.CreatedAt >= leftBound && t.CreatedAt <= rightBound)
            .SumAsync(t => t.Amount);

        return total;
    }

    public async Task<decimal> CalculateTotalConsumptionAsync(Category category, int userId, DateTime leftBound, DateTime rightBound)
    {
        decimal total = 0;
        total = await _dbContext.Transactions
            .Where(t => t.Category == category && t.Amount < 0 && t.UserId == userId
            && t.CreatedAt >= leftBound && t.CreatedAt <= rightBound)
            .SumAsync(t => t.Amount);

        return total;
    }
}
