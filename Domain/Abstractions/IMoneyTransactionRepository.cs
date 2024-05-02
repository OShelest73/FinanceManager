using Domain.Entities;

namespace Domain.Abstractions;

public interface IMoneyTransactionRepository : IBaseRepository<MoneyTransaction>
{
    Task<List<MoneyTransaction>> GetUserTransactionsAsync(int userId);

    Task<List<MoneyTransaction>> GetWalletTransactionsAsync(int walletId);

    Task<List<MoneyTransaction>> GetUserTransactionsByCategoryAsync(int userId, int categoryId);

    Task<List<MoneyTransaction>> GetUserIncomeByCategoryAsync(int userId, int categoryId, DateTime startDate, DateTime dueDate);

    Task<List<MoneyTransaction>> GetUserConsumptionsByCategoryAsync(int userId, int categoryId, DateTime startDate, DateTime dueDate);

    Task<MoneyTransaction> GetByIdAsync(int id);

    Task<decimal> CalculateTotalAsync(Category category, int userId);

    Task<decimal> CalculateTotalIncomeAsync(Category category, int userId, DateTime leftBound, DateTime rightBound);

    Task<decimal> CalculateTotalConsumptionAsync(Category category, int userId, DateTime leftBound, DateTime rightBound);

    Task<Dictionary<string, decimal>> TotalConsumptionByCategoriesAsync(int userId);

    Task<Dictionary<string, decimal>> TotalIncomeByCategoriesAsync(int userId);
}
