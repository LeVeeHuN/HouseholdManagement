using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HHMBApp.Domain.Entities;
using HHMBApp.Infrastructure.Data;
using HHMBApp.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HHMBApp.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context = null!;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User?> CreateUser(User user)
        {
            var result = await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<User?> UpdateUser(User user)
        {
            DetachEntity(user.Id);
            var result = _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<User?> ReadUser(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User?> ReadUser(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<IEnumerable<User>> ReadUsers()
        {
            return await _context.Users.ToListAsync();
        }

        private void DetachEntity(Guid id)
        {
            // Detach any existing tracked instance
            var existingEntries = _context.ChangeTracker.Entries<User>()
                .Where(e => e.Entity.Id == id);
            foreach (var entry in existingEntries)
                entry.State = EntityState.Detached;
        }
    }
}
