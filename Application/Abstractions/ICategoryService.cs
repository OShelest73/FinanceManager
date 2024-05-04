using Application.Dtos.CategoryDtos;

namespace Application.Abstractions;

public interface ICategoryService
{
    Task<List<CategoryDto>> GetAllCategoriesAsync();

    Task<CategoryDto> GetCategoryByIdAsync(int id);

    Task CreateCategoryAsync(CategoryNameDto categoryName);

    Task UpdateCategoryAsync(CategoryDto categoryDto);

    Task DeleteCategoryAsync(int id);
}