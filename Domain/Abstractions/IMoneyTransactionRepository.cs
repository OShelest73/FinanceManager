using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions;

public interface IMoneyTransactionRepository : IBaseRepository<MoneyTransaction>
{
    Task<List<MoneyTransaction>> GetUserTransactionsByCategoryAsync(int userId, int categoryId);

    Task<MoneyTransaction> GetByIdAsync(int id);

    Task<decimal> CalculateTotalAsync(Category category, int userId);

    Task<decimal> CalculateTotalIncomeAsync(Category category, int userId, DateTime leftBound, DateTime rightBound);

    Task<decimal> CalculateTotalConsumptionAsync(Category category, int userId, DateTime leftBound, DateTime rightBound);
}
