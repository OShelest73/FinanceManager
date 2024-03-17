using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions;

public interface IMoneyTransactionRepository : IDisposable
{
    List<MoneyTransaction> GetMoneyTransactions();

    MoneyTransaction GetMoneyTransaction(Func<MoneyTransaction, bool> predicate);

    void Remove(Func<MoneyTransaction, bool> predicate);

    void Save();
}
