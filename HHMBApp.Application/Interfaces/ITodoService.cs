using HHMBApp.Application.DTOs.Todo;
using HHMBApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHMBApp.Application.Interfaces
{
    public interface ITodoService
    {
        Task<CreateTodoResponseDto> CreateTodo(CreateTodoDto createTodoDto);
        Task<IEnumerable<Todo>> ReadAllTodos(Guid householdId);
        Task<CreateTodoResponseDto> UpdateTodo(UpdateTodoDto updateTodoDto);
        Task<DeleteTodoResponseDto> DeleteTodo(Guid id, Guid householdId);
    }
}
