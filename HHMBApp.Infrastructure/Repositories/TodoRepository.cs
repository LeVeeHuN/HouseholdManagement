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
    public class TodoRepository : ITodoRepository
    {
        private readonly AppDbContext _context;

        public TodoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Todo> Create(Todo todo)
        {
            var addedTodo = await _context.Todos.AddAsync(todo);
            await _context.SaveChangesAsync();
            return addedTodo.Entity;
        }

        public async Task<Todo?> Delete(Guid id)
        {
            Todo? todoToDelete = await _context.Todos.FindAsync(id);
            if (todoToDelete == null)
            {
                return null;
            }
            DetachEntity(id);
            _context.Todos.Remove(todoToDelete);
            await _context.SaveChangesAsync();
            return todoToDelete;
        }

        public async Task<Todo?> Read(Guid id)
        {
            return await _context.Todos.FindAsync(id);
        }

        public async Task<IEnumerable<Todo>> ReadAll()
        {
            return await _context.Todos.ToListAsync();
        }

        public async Task<Todo?> Update(Todo todo)
        {
            DetachEntity(todo.Id);
            _context.Todos.Update(todo);
            await _context.SaveChangesAsync();
            return todo;
        }

        private void DetachEntity(Guid id)
        {
            // Detach any existing tracked instance
            var existingEntries = _context.ChangeTracker.Entries<Todo>()
                .Where(e => e.Entity.Id == id);
            foreach (var entry in existingEntries)
                entry.State = EntityState.Detached;
        }
    }
}
