using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.MoneyTransactionDtos;

public class CreateTransactionDto
{
    public decimal Amount { get; set; }
    public string Comment { get; set; }
    public DateTime CreatedAt { get; set; }

    public int WalletId { get; set; }
    public Wallet Wallet { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
