using Domain.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class MoneyTransactionRepository : IMoneyTransactionRepository
{
    private readonly ApplicationDbContext _dbContext;

    public MoneyTransactionRepository(ApplicationDbContext dbContext)
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

    public async Task<MoneyTransaction> GetTransactionByIdAsync(int id)
    {
        var result = await _dbContext.Transactions.FirstOrDefaultAsync(mt => mt.Id == id);

        return result;
    }

    public async Task CreateTransactionAsync(MoneyTransaction transaction)
    {
        _dbContext.Transactions.Add(transaction);

        await SaveAsync();
    }

    public async Task UpdateTransactionAsync(MoneyTransaction transaction)
    {
        _dbContext.Transactions.Update(transaction);

        await SaveAsync();
    }

    public async Task DeleteTransactionAsync(MoneyTransaction transaction)
    {
        _dbContext.Transactions.Remove(transaction);

        await SaveAsync();
    }

    public async Task SaveAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}
