using HHMBApp.Domain.Entities;
using HHMBApp.Infrastructure.Data;
using HHMBApp.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHMBApp.Infrastructure.Repositories
{
    public class GroceryListItemRepository : IGroceryListItemRepository
    {
        private readonly AppDbContext _context;

        public GroceryListItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<GroceryListItem> Create(GroceryListItem groceryListItem)
        {
            var result = await _context.GroceryListItems.AddAsync(groceryListItem);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<GroceryListItem?> Delete(Guid id)
        {
            var result = await _context.GroceryListItems.FindAsync(id);
            if (result == null)
            {
                return null;
            }
            _context.GroceryListItems.Remove(result);
            await _context.SaveChangesAsync();
            return result;
        }

        public async Task<GroceryListItem?> Read(Guid id)
        {
            return await _context.GroceryListItems.FindAsync(id);
        }

        public async Task<IEnumerable<GroceryListItem>> ReadAll()
        {
            return await _context.GroceryListItems.ToListAsync();
        }

        public async Task<GroceryListItem?> Update(GroceryListItem groceryListItem)
        {
            var updated = _context.GroceryListItems.Update(groceryListItem);
            await _context.SaveChangesAsync();
            return updated.Entity;
        }
    }
}
