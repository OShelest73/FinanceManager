namespace Domain.Entities;

public class FinancialGoal
{
    public int Id { get; set; }
    public decimal MoneyAmount { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime DueDate { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }
}
