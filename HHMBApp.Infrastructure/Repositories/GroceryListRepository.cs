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
    public class GroceryListRepository : IGroceryListRepository
    {
        private readonly AppDbContext _context;

        public GroceryListRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<GroceryList> Create(GroceryList groceryList)
        {
            var result = await _context.GroceryLists.AddAsync(groceryList);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<GroceryList?> Delete(Guid id)
        {
            var result = await _context.GroceryLists.FindAsync(id);
            if (result ==  null)
            {
                return null;
            }
            _context.GroceryLists.Remove(result);
            await _context.SaveChangesAsync();
            return result;
        }

        public async Task<GroceryList?> Read(Guid id)
        {
            return await _context.GroceryLists.FindAsync(id);
        }

        public async Task<IEnumerable<GroceryList>> ReadAll()
        {
            return await _context.GroceryLists.ToListAsync();
        }

        public async Task<GroceryList?> Update(GroceryList groceryList)
        {
            var result = await _context.GroceryLists.FindAsync(groceryList.Id);
            if (result == null)
            {
                return null;
            }
            var updated = _context.GroceryLists.Update(groceryList);
            await _context.SaveChangesAsync();
            return updated.Entity;
        }
    }
}
