using HHMBApp.Application.DTOs.Todo;
using HHMBApp.Application.Interfaces;
using HHMBApp.Domain.Entities;
using HHMBApp.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HHMBApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpPost]
        public async Task<ActionResult<CreateTodoResponseDto>> CreateTodo([FromBody] CreateTodoDto request)
        {
            var result = await _todoService.CreateTodo(request);
            if (result == null)
            {
                return BadRequest();
            }
            if (result.Result != CreateTodoResponseStatus.OK)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Todo>>> GetTodosForHousehold([FromQuery] Guid householdId)
        {
            if (householdId == Guid.Empty)
            {
                return BadRequest();
            }

            var result = await _todoService.ReadAllTodos(householdId);

            if (result == null) // Might never be null, I don't know, better be safe than sorry I guess
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<CreateTodoResponseDto>> UpdateTodo([FromBody] UpdateTodoDto request)
        {
            var result = await _todoService.UpdateTodo(request);

            if (result == null)
            {
                return BadRequest();
            }

            if (result.Result != CreateTodoResponseStatus.OK)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult<DeleteTodoResponseDto>> DeleteTodo([FromBody] DeleteTodoDto request)
        {
            var result = await _todoService.DeleteTodo(request.TodoId, request.HouseholdId);

            if (result == null)
            {
                return BadRequest();
            }

            if (result.Result != DeleteTodoResponseStatus.OK)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
