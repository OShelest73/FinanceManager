using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class MoneyTransaction
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public string Comment { get; set; }
    public DateTime CreatedAt { get; set; }

    public int WalletId { get; set; }
    public Wallet Wallet { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }
}
