using Domain.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CategoryRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Category>> GetAllCategoriesAsync()
    {
        var result = await _dbContext.Categories.ToListAsync();

        return result;
    }

    public async Task<Category> GetCategoryByIdAsync(int id)
    {
        var result = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);

        return result;
    }
}
