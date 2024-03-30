using Domain.Entities;

namespace Domain.Abstractions;

public interface ICategoryRepository
{
    Task<List<Category>> GetAllCategoriesAsync();

    Task<Category> GetCategoryByIdAsync(int id);
}
