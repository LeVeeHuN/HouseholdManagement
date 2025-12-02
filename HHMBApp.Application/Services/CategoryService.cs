using HHMBApp.Application.DTOs.Category;
using HHMBApp.Application.Interfaces;
using HHMBApp.Domain.Entities;
using HHMBApp.Infrastructure.Interfaces;

namespace HHMBApp.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    
    public async Task<CreateCategoryResponseDto> CreateCategory(string name, Guid householdId)
    {
        // Check if category with the given name already exists for household
        var categories = await _categoryRepository.Read(name);
        var category = categories.FirstOrDefault(c => c.HouseholdId == householdId);

        if (category != null)
        {
            return new CreateCategoryResponseDto()
            {
                Id = Guid.Empty,
                Name = name,
                Result = CreateCategoryResponseStatus.CreateCategoryError
            };
        }
        
        Category newCategory = new Category() {CategoryName = name, HouseholdId = householdId};
        Category? createdCategory = await _categoryRepository.Create(newCategory);

        if (createdCategory == null)
        {
            return new CreateCategoryResponseDto()
            {
                Id = Guid.Empty,
                Name = name,
                Result = CreateCategoryResponseStatus.CreateCategoryError
            };
        }
        
        return new CreateCategoryResponseDto()
        {
            Id = createdCategory.Id,
            Name = createdCategory.CategoryName,
            Result = CreateCategoryResponseStatus.OK
        };
    }

    public async Task<IEnumerable<Category>> GetCategories(Guid householdId)
    {
        var categories = await _categoryRepository.ReadAll();
        return categories.Where(c => c.HouseholdId == householdId);
    }

    public async Task<DeleteCategoryResponseDto> DeleteCategory(string name, Guid householdId)
    {
        var categories = await _categoryRepository.Read(name);
        Category? category = categories.FirstOrDefault(c => c.HouseholdId == householdId);

        if (category == null)
        {
            return new DeleteCategoryResponseDto()
            {
                Name = name,
                Result = DeleteCategoryResponseStatus.DeleteCategoryError
            };
        }
        
        await _categoryRepository.Delete(category.Id);

        return new DeleteCategoryResponseDto()
        {
            Name = name,
            Result = DeleteCategoryResponseStatus.OK
        };
    }
}