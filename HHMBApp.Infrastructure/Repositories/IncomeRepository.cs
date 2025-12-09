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
    public class IncomeRepository : IIncomeRepository
    {
        private readonly AppDbContext _context = null!;

        public IncomeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Income> Create(Income income)
        {
            var addedIncome = await _context.Incomes.AddAsync(income);
            await _context.SaveChangesAsync();
            return addedIncome.Entity;

        }

        public async Task<Income?> Delete(Guid id)
        {
            var incomeToDelete = await _context.Incomes.FirstOrDefaultAsync(i => i.Id == id);
            if (incomeToDelete == null)
            {
                return null;
            }
            DetachEntity(id);
            _context.Incomes.Remove(incomeToDelete);
            await _context.SaveChangesAsync();
            return incomeToDelete;
        }

        public async Task<Income?> Read(Guid id)
        {
            return await _context.Incomes.FindAsync(id);
        }

        public async Task<IEnumerable<Income>> ReadAll()
        {
            return await _context.Incomes.ToListAsync();
        }

        public async Task<Income?> Update(Income income)
        {
            DetachEntity(income.Id);
            _context.Update(income);
            await _context.SaveChangesAsync();
            return income;
        }

        private void DetachEntity(Guid id)
        {
            // Detach any existing tracked instance
            var existingEntries = _context.ChangeTracker.Entries<Income>()
                .Where(e => e.Entity.Id == id);
            foreach (var entry in existingEntries)
                entry.State = EntityState.Detached;
        }
    }
}
