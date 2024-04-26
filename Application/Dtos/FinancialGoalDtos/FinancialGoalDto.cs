using Domain.Entities;

namespace Application.Dtos.FinancialGoalDtos;

public class FinancialGoalDto
{
    public int Id { get; set; }

    public decimal MoneyAmount { get; set; }

    private DateTime startDate { get; set; }
    public string StartDate
    {
        get { return startDate.ToString("HH:mm dd-MM-yyyy"); }
        set { startDate = DateTime.Parse(value); }
    }

    private DateTime dueDate { get; set; }
    public string DueDate
    {
        get { return dueDate.ToString("HH:mm dd-MM-yyyy"); }
        set { dueDate = DateTime.Parse(value); }
    }

    public decimal CurrentTotal { get; set; }

    public bool IsIncome
    {
        get { return MoneyAmount > 0; }
    }

    public Category Category { get; set; }
}
