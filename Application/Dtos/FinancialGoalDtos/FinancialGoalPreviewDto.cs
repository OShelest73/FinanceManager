using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.FinancialGoalDtos;

public class FinancialGoalPreviewDto
{
    public int Id { get; set; }

    public decimal MoneyAmount { get; set; }

    public decimal CurrentTotal { get; set; }

    public Category Category { get; set; }
}
