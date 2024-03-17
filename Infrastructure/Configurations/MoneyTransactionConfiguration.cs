using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class MoneyTransactionConfiguration
{
    public void Configure(EntityTypeBuilder<MoneyTransaction> builder)
    {
        builder.ToTable("MoneyTransactions")
            .HasKey(mt => mt.Id);

        builder.Property(mt => mt.Amount).IsRequired();
        builder.Property(mt => mt.CreatedAt).IsRequired();
        builder.HasOne(mt => mt.Wallet)
            .WithMany()
            .IsRequired();
        builder.HasOne(mt => mt.Category)
            .WithMany();
    }
}
