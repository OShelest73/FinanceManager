using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class FinancialGoal
{
    public int Id { get; set; }
    public decimal MoneyAmount { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime DueDate { get; set; }
    public Category Category { get; set; }
}
