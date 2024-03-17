using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Wallet
{
    public int Id { get; set; }
    public string WalletName { get; set; }
    public decimal MoneyAmount { get; set; }
}
