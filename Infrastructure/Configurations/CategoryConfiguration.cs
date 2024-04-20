using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security;

namespace Infrastructure.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories")
            .HasKey(c => c.Id);

        builder.Property(c => c.CategoryName).IsRequired();

        builder.HasData(
        new[]
            {
                new Category{ Id = 1, CategoryName = "Рестораны / бары / кафе" },
                new Category{ Id = 2, CategoryName = "Продуктовые магазины" },
                new Category{ Id = 3, CategoryName = "Денежные переводы" },
                new Category{ Id = 4, CategoryName = "Поставщик услуг" },
                new Category{ Id = 5, CategoryName = "Операции с наличными" },
                new Category{ Id = 6, CategoryName = "Зарплата" },
                new Category{ Id = 7, CategoryName = "Развлечения" },
                new Category{ Id = 8, CategoryName = "Медицина" },
                new Category{ Id = 9, CategoryName = "Одежда и аксессуары" },
                new Category{ Id = 10, CategoryName = "Подарки" },
                new Category{ Id = 11, CategoryName = "Налоги" },
                new Category{ Id = 12, CategoryName = "Кредиты и ипотека" },
           });
    }
}
