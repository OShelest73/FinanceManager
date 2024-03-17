using Application.Abstractions;
using Domain.Abstractions;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;
    private MoneyTransactionRepository _moneyTransaction;

    public IMoneyTransactionRepository MoneyTransaction
    {
        get
        {
            if (_moneyTransaction == null)
            {
                _moneyTransaction = new MoneyTransactionRepository(_dbContext);
            }
            return _moneyTransaction;
        }
    }

    #region IDisposableImpl
    private bool disposed = false;

    public virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
            disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    #endregion
}
