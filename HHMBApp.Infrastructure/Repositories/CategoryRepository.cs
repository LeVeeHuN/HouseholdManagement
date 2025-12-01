using HHMBApp.Domain.Entities;
using HHMBApp.Infrastructure.Data;
using HHMBApp.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HHMBApp.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _context;

    public CategoryRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<Category?> Create(Category category)
    {
        var result = await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<IEnumerable<Category>> Read(string name)
    {
        return await _context.Categories.Where(c => c.CategoryName == name).ToListAsync();
    }

    public async Task<Category?> Read(Guid id)
    {
        return await _context.Categories.FindAsync(id);
    }

    public async Task<IEnumerable<Category>> ReadAll()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<Category?> Update(Category category)
    {
        var result = _context.Categories.Update(category);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<Category?> Delete(Guid id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null)
        {
            return null;
        }
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
        return category;
    }
}