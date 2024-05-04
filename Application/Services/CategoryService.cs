using Application.Abstractions;
using Application.Dtos.CategoryDtos;
using AutoMapper;
using Domain.Abstractions;
using Domain.Entities;

namespace Application.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<List<CategoryDto>> GetAllCategoriesAsync()
    {
        var dbCategories = await _categoryRepository.GetAllAsync();

        var viewCategories = _mapper.Map<List<CategoryDto>>(dbCategories);

        return viewCategories;
    }

    public async Task<CategoryDto> GetCategoryByIdAsync(int id)
    {
        var dbCategory = await _categoryRepository.GetByIdAsync(id);

        var viewCategory = _mapper.Map<CategoryDto>(dbCategory);

        return viewCategory;
    }

    public async Task CreateCategoryAsync(CategoryNameDto categoryName)
    {
        var category = new Category
        {
            CategoryName = categoryName.CategoryName,
        };

        await _categoryRepository.CreateAsync(category);
    }

    public async Task UpdateCategoryAsync(CategoryDto categoryDto)
    {
        var dbCategory = _mapper.Map<Category>(categoryDto);

        await _categoryRepository.UpdateAsync(dbCategory);
    }

    public async Task DeleteCategoryAsync(int id)
    {
        await _categoryRepository.DeleteByIdAsync(id);
    }
}
