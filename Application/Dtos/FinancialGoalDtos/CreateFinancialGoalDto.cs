namespace Application.Dtos.FinancialGoalDtos;

public class CreateFinancialGoalDto
{
    public decimal MoneyAmount { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime DueDate { get; set; }

    public int CategoryId { get; set; }

    public int UserId { get; set; }
}
