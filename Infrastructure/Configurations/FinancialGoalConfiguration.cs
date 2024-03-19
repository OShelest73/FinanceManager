using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class FinancialGoalConfiguration : IEntityTypeConfiguration<FinancialGoal>
{
    public void Configure(EntityTypeBuilder<FinancialGoal> builder)
    {
        builder.ToTable("FinancialGoals")
            .HasKey(fg => fg.Id);

        builder.Property(fg => fg.MoneyAmount)
            .HasPrecision(18, 4)
            .IsRequired();
        builder.Property(fg => fg.StartDate).IsRequired();
        builder.Property(fg => fg.DueDate).IsRequired();
        builder.HasOne(fg => fg.Category)
            .WithMany()
            .IsRequired();
    }
}
