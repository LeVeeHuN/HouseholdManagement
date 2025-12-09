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
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly AppDbContext _context = null!;

        public ExpenseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Expense> Create(Expense expense)
        {
            var addedExpense = await _context.Expenses.AddAsync(expense);
            await _context.SaveChangesAsync();
            return addedExpense.Entity;
        }

        public async Task<Expense?> Delete(Guid id)
        {
            Expense? expenseToDelete = await _context.Expenses.FindAsync(id);

            if (expenseToDelete == null)
            {
                return null;
            }
            DetachEntity(id);
            _context.Expenses.Remove(expenseToDelete);
            await _context.SaveChangesAsync();

            return expenseToDelete;
        }

        public async Task<Expense?> Read(Guid id)
        {
            return await _context.Expenses.FindAsync(id);
        }

        public async Task<IEnumerable<Expense>> ReadAll()
        {
            return await _context.Expenses.ToListAsync();
        }

        public async Task<Expense?> Update(Expense expense)
        {
            DetachEntity(expense.Id);
            _context.Expenses.Update(expense);
            await _context.SaveChangesAsync();

            return expense;
        }

        private void DetachEntity(Guid id)
        {
            // Detach any existing tracked instance
            var existingEntries = _context.ChangeTracker.Entries<Expense>()
                .Where(e => e.Entity.Id == id);
            foreach (var entry in existingEntries)
                entry.State = EntityState.Detached;
        }
    }
}
