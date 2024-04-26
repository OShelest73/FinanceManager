using Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Application.Dtos.MoneyTransactionDtos;

public class TransactionViewDto
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public string Comment { get; set; }

    private DateTime createdAt;
    public string CreatedAt
    {
        get { return createdAt.ToString("HH:mm dd-MM-yyyy"); }
        set { createdAt = DateTime.Parse(value); }
    }

    public int WalletId { get; set; }
    public Wallet Wallet { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
