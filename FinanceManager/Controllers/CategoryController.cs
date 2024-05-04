using Application.Abstractions;
using Application.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<ActionResult> GetAllCategoriesAsync()
    {
        var categories = await _categoryService.GetAllCategoriesAsync();

        return Ok(categories);
    }

    [HttpGet("detailed")]
    public async Task<ActionResult> GetCategoryAsync(int id)
    {
        var categories = await _categoryService.GetCategoryByIdAsync(id);

        return Ok(categories);
    }

    [HttpPost]
    public async Task<ActionResult> CreateCategoryAsync(CategoryNameDto categoryName)
    {
        await _categoryService.CreateCategoryAsync(categoryName);

        return Ok();
    }

    [HttpPut]
    public async Task<ActionResult> UpdateCategoryAsync(CategoryDto category)
    {
        await _categoryService.UpdateCategoryAsync(category);

        return Ok();
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteCategoryAsync(int id)
    {
        await _categoryService.DeleteCategoryAsync(id);

        return Ok();
    }
}
