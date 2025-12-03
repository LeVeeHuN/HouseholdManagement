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
    public class WIshRepository : IWishRepository
    {
        private readonly AppDbContext _context;

        public WIshRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Wish> Create(Wish wish)
        {
            var result = await _context.Wishes.AddAsync(wish);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Wish?> Delete(Guid id)
        {
            Wish? wishToDelete = await _context.Wishes.FindAsync(id);
            if (wishToDelete == null)
            {
                return null;
            }
            _context.Wishes.Remove(wishToDelete);
            await _context.SaveChangesAsync();
            return wishToDelete;
        }

        public async Task<Wish?> Read(Guid id)
        {
            return await _context.Wishes.FindAsync(id);
        }

        public async Task<IEnumerable<Wish>> ReadAll()
        {
            return await _context.Wishes.ToListAsync();
        }

        public async Task<Wish?> Update(Wish wish)
        {
            Wish? wishToUpdate = await _context.Wishes.FindAsync(wish.Id);
            if (wishToUpdate == null)
            {
                return null;
            }
            _context.Wishes.Update(wish);
            await _context.SaveChangesAsync();
            return wish;
        }
    }
}
