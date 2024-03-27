using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions;

public interface IMoneyTransactionRepository
{
    Task<List<MoneyTransaction>> GetUserTransactionsByCategoryAsync(int userId, int categoryId);

    Task<MoneyTransaction> GetTransactionByIdAsync(int id);

    Task CreateTransactionAsync(MoneyTransaction transaction);

    Task UpdateTransactionAsync(MoneyTransaction transaction);

    Task DeleteTransactionAsync(MoneyTransaction transaction);

    Task SaveAsync();
}
