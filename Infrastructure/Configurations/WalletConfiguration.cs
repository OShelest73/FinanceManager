using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class WalletConfiguration
{
    public void Configure(EntityTypeBuilder<Wallet> builder)
    {
        builder.ToTable("Wallets")
            .HasKey(w => w.Id);

        builder.Property(w => w.WalletName).IsRequired();
        builder.Property(w => w.MoneyAmount).IsRequired();
    }
}
