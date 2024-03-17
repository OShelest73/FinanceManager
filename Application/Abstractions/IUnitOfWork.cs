using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions;

public interface IUnitOfWork : IDisposable
{
    IMoneyTransactionRepository MoneyTransaction{ get; }
}
