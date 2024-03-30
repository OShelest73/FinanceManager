using Application.Dtos.CategoryDtos;
using AutoMapper;
using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services;

public class CategoryService
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
        var dbCategories = await _categoryRepository.GetAllCategoriesAsync();

        var viewCategories = _mapper.Map<List<CategoryDto>>(dbCategories);

        return viewCategories;
    }

    public async Task<CategoryDto> GetCategoryById(int id)
    {
        var dbCategory = await _categoryRepository.GetCategoryByIdAsync(id);

        var viewCategory = _mapper.Map<CategoryDto>(dbCategory);

        return viewCategory;
    }
}
