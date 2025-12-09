using HHMBApp.Application.DTOs.Expense;
using HHMBApp.Application.Interfaces;
using HHMBApp.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HHMBApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseService _expenseService;

        public ExpenseController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        [HttpPost]
        public async Task<ActionResult<CreateExpenseResponseDto>> CreateExpense([FromBody] CreateExpenseDto request)
        {
            var response = await _expenseService.CreateExpense(request);
            if (response.Response != CreateExpenseResponseStatus.OK)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<CreateExpenseResponseDto>> UpdateExpense([FromBody] UpdateExpenseDto request)
        {
            var response = await _expenseService.UpdateExpense(request);
            if (response.Response != CreateExpenseResponseStatus.OK)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Expense>>> ReadExpensesForHousehold([FromQuery] Guid householdId)
        {
            if (householdId == Guid.Empty)
            {
                return BadRequest();
            }
            var expenses = await _expenseService.ReadExpenses(householdId);
            return Ok(expenses);
        }

        [HttpDelete]
        public async Task<ActionResult<DeleteExpenseResponseDto>> DeleteExpense([FromBody] DeleteExpenseDto request)
        {
            var response = await _expenseService.DeleteExpense(request.ExpenseId, request.HouseholdId);
            if (response.Response != DeleteExpenseResponseStatus.OK)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
