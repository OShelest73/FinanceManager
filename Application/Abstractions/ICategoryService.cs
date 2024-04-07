using Application.Dtos.CategoryDtos;

namespace Application.Abstractions;

public interface ICategoryService
{
    Task<List<CategoryDto>> GetAllCategoriesAsync();

    Task<CategoryDto> GetCategoryById(int id);
}