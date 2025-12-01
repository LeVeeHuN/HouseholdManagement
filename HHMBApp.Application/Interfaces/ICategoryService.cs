using HHMBApp.Application.DTOs;
using HHMBApp.Domain.Entities;

namespace HHMBApp.Application.Interfaces;

public interface ICategoryService
{
    // Create category for household
    // Get categories for household
    // Delete category for household

    Task<CreateCategoryResponseDto> CreateCategory(string name, Guid householdId);
    Task<IEnumerable<Category>> GetCategories(Guid householdId);
    Task<DeleteCategoryResponseDto> DeleteCategory(string name, Guid householdId);
}