using Domain.Entities;

namespace Application.Dtos.FinancialGoalDtos;

public class FinancialGoalPreviewDto
{
    public int Id { get; set; }

    public decimal MoneyAmount { get; set; }

    public decimal CurrentTotal { get; set; }

    public Category Category { get; set; }
}
