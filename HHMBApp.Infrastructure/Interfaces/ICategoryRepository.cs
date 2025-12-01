using HHMBApp.Domain.Entities;

namespace HHMBApp.Infrastructure.Interfaces;

public interface ICategoryRepository
{
    Task<Category?> Create(Category category);
    Task<IEnumerable<Category>> Read(string name);
    Task<Category?> Read(Guid id);
    Task<IEnumerable<Category>> ReadAll();
    Task<Category?> Update(Category category);
    Task<Category?> Delete(Guid id);
}