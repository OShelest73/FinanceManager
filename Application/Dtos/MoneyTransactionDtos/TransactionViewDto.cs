using Domain.Entities;

namespace Application.Dtos.MoneyTransactionDtos;

public class TransactionViewDto
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public string Comment { get; set; }
    public DateTime CreatedAt { get; set; }

    public int WalletId { get; set; }
    public Wallet Wallet { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
