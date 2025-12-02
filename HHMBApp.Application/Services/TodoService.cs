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

        public async Task<CreateTodoResponseDto> CreateTodo(CreateTodoDto createTodoDto)
        {
            Todo newTodo = new Todo
            {
                Id = Guid.NewGuid(),
                DeadLine = createTodoDto.DeadLine,
                CreatedByUserId = createTodoDto.CreatedByUserId,
                AssignedToUserId = createTodoDto.AssignedToUserId,
                ClosedByUserId = createTodoDto.ClosedByUserId,
                ClosedAt = createTodoDto.ClosedAt,
                Title = createTodoDto.Title,
                Description = createTodoDto.Description,
                HouseholdId = createTodoDto.HouseholdId,
                CreatedAt = createTodoDto.CreatedAt
            };

            Todo createdTodo = await _todoRepository.Create(newTodo);

            return new CreateTodoResponseDto
            {
                Id = createdTodo.Id,
                DeadLine = createdTodo.DeadLine,
                CreatedByUserId = createdTodo.CreatedByUserId,
                AssignedToUserId = createdTodo.AssignedToUserId,
                ClosedByUserId = createdTodo.ClosedByUserId,
                ClosedAt = createdTodo.ClosedAt,
                Title = createdTodo.Title,
                Description = createdTodo.Description,
                HouseholdId = createdTodo.HouseholdId,
                CreatedAt = createdTodo.CreatedAt,
                Result = CreateTodoResponseStatus.OK
            };
        }

        public async Task<DeleteTodoResponseDto> DeleteTodo(Guid id, Guid householdId)
        {
            // Check if Todo exists and belongs to the given household
            Todo? todoToDelete = await _todoRepository.Read(id);

            if (todoToDelete == null || todoToDelete.HouseholdId != householdId)
            {
                return new DeleteTodoResponseDto
                {
                    Id = id,
                    Result = DeleteTodoResponseStatus.DeleteTodoError
                };
            }

            await _todoRepository.Delete(id);
            return new DeleteTodoResponseDto
            {
                Id = id,
                Result = DeleteTodoResponseStatus.OK
            };
        }

        public async Task<IEnumerable<Todo>> ReadAllTodos(Guid householdId)
        {
            var todos = await _todoRepository.ReadAll();
            return todos.Where(t => t.HouseholdId == householdId);
        }

        public async Task<CreateTodoResponseDto> UpdateTodo(UpdateTodoDto updateTodoDto)
        {
            // Check if todo exists
            Todo? todoToUpdate = await _todoRepository.Read(updateTodoDto.Id);
            if (todoToUpdate == null)
            {
                return new CreateTodoResponseDto
                {
                    Id = updateTodoDto.Id,
                    DeadLine = updateTodoDto.DeadLine,
                    CreatedByUserId = updateTodoDto.CreatedByUserId,
                    AssignedToUserId = updateTodoDto.AssignedToUserId,
                    ClosedByUserId = updateTodoDto.ClosedByUserId,
                    ClosedAt = updateTodoDto.ClosedAt,
                    Title = updateTodoDto.Title,
                    Description = updateTodoDto.Description,
                    HouseholdId = updateTodoDto.HouseholdId,
                    CreatedAt = updateTodoDto.CreatedAt,
                    Result = CreateTodoResponseStatus.UpdateTodoError
                };
            }

            // Update todo
            Todo newTodo = new Todo
            {
                Id = updateTodoDto.Id,
                CreatedAt = updateTodoDto.CreatedAt,
                DeadLine = updateTodoDto.DeadLine,
                CreatedByUserId = updateTodoDto.CreatedByUserId,
                AssignedToUserId = updateTodoDto.AssignedToUserId,
                ClosedByUserId = updateTodoDto.ClosedByUserId,
                ClosedAt = updateTodoDto.ClosedAt,
                Title = updateTodoDto.Title,
                Description = updateTodoDto.Description,
                HouseholdId = updateTodoDto.HouseholdId
            };

            Todo? result = await _todoRepository.Update(newTodo);

            if (result == null)
            {
                return new CreateTodoResponseDto
                {
                    Id = updateTodoDto.Id,
                    DeadLine = updateTodoDto.DeadLine,
                    CreatedByUserId = updateTodoDto.CreatedByUserId,
                    AssignedToUserId = updateTodoDto.AssignedToUserId,
                    ClosedByUserId = updateTodoDto.ClosedByUserId,
                    ClosedAt = updateTodoDto.ClosedAt,
                    Title = updateTodoDto.Title,
                    Description = updateTodoDto.Description,
                    HouseholdId = updateTodoDto.HouseholdId,
                    CreatedAt = updateTodoDto.CreatedAt,
                    Result = CreateTodoResponseStatus.UpdateTodoError
                };
            }

            return new CreateTodoResponseDto
            {
                Id = result.Id,
                DeadLine = result.DeadLine,
                CreatedByUserId = result.CreatedByUserId,
                AssignedToUserId = result.AssignedToUserId,
                ClosedByUserId = result.ClosedByUserId,
                ClosedAt = result.ClosedAt,
                Title = result.Title,
                Description = result.Description,
                HouseholdId = result.HouseholdId,
                CreatedAt = result.CreatedAt,
                Result = CreateTodoResponseStatus.OK
            };
        }
    }
}
