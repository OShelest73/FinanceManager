using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class CategoryConfiguration
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories")
            .HasKey(c => c.Id);

        builder.Property(c => c.CategoryName).IsRequired();
    }
}
