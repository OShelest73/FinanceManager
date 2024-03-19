using Application.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class MoneyTransactionRepository : IMoneyTransactionRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly DbSet<MoneyTransaction> _moneyTransactions;

    public MoneyTransactionRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        _moneyTransactions = _dbContext.Set<MoneyTransaction>();
    }

    public MoneyTransaction GetMoneyTransaction(Func<MoneyTransaction, bool> predicate)
    {
        var result = _moneyTransactions.FirstOrDefault(predicate);

        return result;
    }

    public List<MoneyTransaction> GetMoneyTransactions()
    {
        var result = _moneyTransactions.ToList();

        return result;
    }

    public void Remove(Func<MoneyTransaction, bool> predicate)
    {
        _moneyTransactions.Remove(GetMoneyTransaction(predicate));
    }

    public void Save()
    {
        _dbContext.SaveChanges();
    }
}
