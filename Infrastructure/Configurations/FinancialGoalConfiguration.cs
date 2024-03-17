using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class FinancialGoalConfiguration
{
    public void Configure(EntityTypeBuilder<FinancialGoal> builder)
    {
        builder.ToTable("FinancialGoals")
            .HasKey(fg => fg.Id);

        builder.Property(fg => fg.MoneyAmount).IsRequired();
        builder.Property(fg => fg.StartDate).IsRequired();
        builder.Property(fg => fg.DueDate).IsRequired();
        builder.HasOne(fg => fg.Category)
            .WithMany()
            .IsRequired();
    }
}
