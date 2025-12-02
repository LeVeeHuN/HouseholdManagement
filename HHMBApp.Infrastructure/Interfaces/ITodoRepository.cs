using HHMBApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHMBApp.Infrastructure.Interfaces
{
    public interface ITodoRepository
    {
        Task<Todo> Create(Todo todo);
        Task<Todo?> Read(Guid id);
        Task<IEnumerable<Todo>> ReadAll();
        Task<Todo?> Update(Todo todo);
        Task<Todo?> Delete(Guid id);
    }
}
