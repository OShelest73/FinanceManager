using Domain.Entities;

namespace Application.Dtos.MoneyTransactionDtos;

public class TransactionPreviewDto
{
    public int Id { get; set; }
    public decimal Amount { get; set; }

    private DateTime createdAt;
    public string CreatedAt
    {
        get { return createdAt.ToString("HH:mm dd-MM-yyyy"); }
        set { createdAt = DateTime.Parse(value); }
    }

    public Category Category { get; set; }
}
