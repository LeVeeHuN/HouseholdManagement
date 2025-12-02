using HHMBApp.Application.DTOs.Todo;
using HHMBApp.Application.Interfaces;
using HHMBApp.Domain.Entities;
using HHMBApp.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHMBApp.Application.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;

        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public Task<CreateTodoResponseDto> CreateTodo(CreateTodoDto createTodoDto)
        {
            throw new NotImplementedException();
        }

        public Task<DeleteTodoResponseDto> DeleteTodo(Guid id, Guid householdId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Todo>> ReadAllTodos(Guid householdId)
        {
            throw new NotImplementedException();
        }

        public Task<CreateTodoResponseDto> UpdateTodo(UpdateTodoDto updateTodoDto)
        {
            throw new NotImplementedException();
        }
    }
}
