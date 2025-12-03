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
    public class HouseholdRepository : IHouseholdRepository
    {
        private readonly AppDbContext _context;

        public HouseholdRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Household> Create(Household household)
        {
            var result = await _context.Households.AddAsync(household);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Household?> Delete(Guid id)
        {
            var result = await _context.Households.FindAsync(id);
            if (result == null)
            {
                return null;
            }
            _context.Households.Remove(result);
            await _context.SaveChangesAsync();
            return result;
        }

        public async Task<Household?> Read(Guid id)
        {
            return await _context.Households.FindAsync(id);
        }

        public async Task<IEnumerable<Household>> ReadAll()
        {
            return await _context.Households.ToListAsync();
        }

        public async Task<Household?> Update(Household household)
        {
            var result = await _context.Households.FindAsync(household.Id);
            if (result == null)
            {
                return null;
            }

            _context.Households.Update(household);
            await _context.SaveChangesAsync();
            return household;
        }
    }
}
