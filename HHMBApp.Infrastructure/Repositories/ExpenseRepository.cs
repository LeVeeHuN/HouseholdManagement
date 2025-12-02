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
            Expense? expenseToUpdate = await _context.Expenses.FindAsync(expense.Id);

            if (expenseToUpdate == null)
            {
                return null;
            }

            _context.Expenses.Update(expense);
            await _context.SaveChangesAsync();

            return expense;
        }
    }
}
