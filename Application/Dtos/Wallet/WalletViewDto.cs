﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Wallet;

public class WalletViewDto
{
    public int Id { get; set; }
    public string WalletName { get; set; }
    public decimal MoneyAmount { get; set; }
}
