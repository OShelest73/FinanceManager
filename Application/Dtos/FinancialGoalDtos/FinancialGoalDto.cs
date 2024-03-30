using Domain.Entities;

namespace Application.Dtos.FinancialGoalDtos;

public class FinancialGoalDto
{
    public int Id { get; set; }
    public decimal MoneyAmount { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime DueDate { get; set; }

    public decimal CurrentTotal { get; set; }

    public Category Category { get; set; }
}
