using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class MoneyTransactionConfiguration : IEntityTypeConfiguration<MoneyTransaction>
{
    public void Configure(EntityTypeBuilder<MoneyTransaction> builder)
    {
        builder.ToTable("MoneyTransactions")
            .HasKey(mt => mt.Id);

        builder.Property(mt => mt.Amount)
            .HasPrecision(18, 4)
            .IsRequired();
        builder.Property(mt => mt.Comment).IsRequired(false);
        builder.Property(mt => mt.CreatedAt).IsRequired();
        builder.HasOne(mt => mt.Wallet)
            .WithMany()
            .IsRequired();
        builder.HasOne(mt => mt.Category)
            .WithMany()
            .IsRequired(false);
    }
}
