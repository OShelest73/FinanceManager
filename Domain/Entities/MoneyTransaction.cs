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
    public Wallet Wallet { get; set; }
    public Category Category { get; set; }
}
