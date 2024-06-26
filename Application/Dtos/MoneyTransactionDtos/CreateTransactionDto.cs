﻿namespace Application.Dtos.MoneyTransactionDtos;

public class CreateTransactionDto
{
    public decimal Amount { get; set; }

    public string Comment { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int WalletId { get; set; }

    public int CategoryId { get; set; }

    public int UserId { get; set; }
}
