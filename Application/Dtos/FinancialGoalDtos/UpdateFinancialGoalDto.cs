namespace Application.Dtos.FinancialGoalDtos;

public class UpdateFinancialGoalDto
{
    public int Id { get; set; }

    public decimal MoneyAmount { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime DueDate { get; set; }

    public int CategoryId { get; set; }

    public int UserId { get; set; }
}
