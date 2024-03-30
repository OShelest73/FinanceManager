using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions;

public class TransactionNotFoundException : Exception
{
    public int TransactionId { get; set; }

    public TransactionNotFoundException() : base("Транзакций по вашему запросу не найдено") { }

    public TransactionNotFoundException(int transactionId) : base($"Транзакция с id = '{transactionId}' не найдена")
    {
        TransactionId = transactionId;
    }
}
