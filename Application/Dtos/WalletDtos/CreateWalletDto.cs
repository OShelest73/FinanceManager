using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.WalletDtos;

public class CreateWalletDto
{
    public string WalletName { get; set; }
    public decimal MoneyAmount { get; set; }

    public int UserId { get; set; }
}
