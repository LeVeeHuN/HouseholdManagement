using HHMBApp.Application.DTOs.Income;
using HHMBApp.Application.Interfaces;
using HHMBApp.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HHMBApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class IncomeController : ControllerBase
    {
        private readonly IIncomeService _incomeService;

        public IncomeController(IIncomeService incomeService)
        {
            _incomeService = incomeService;
        }

        [HttpPost]
        public async Task<ActionResult<CreateIncomeResponseDto>> CreateIncome([FromBody] CreateIncomeDto request)
        {
            var response = await _incomeService.CreateIncome(request);
            if (response.Result != CreateIncomeResultStatus.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<CreateIncomeResponseDto>> UpdateIncome([FromBody] UpdateIncomeDto request)
        {
            var response = await _incomeService.UpdateIncome(request);
            if (response.Result != CreateIncomeResultStatus.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Income>>> GetIncomes([FromQuery] Guid householdId)
        {
            var incomes = await _incomeService.ReadIncomes(householdId);
            return Ok(incomes);
        }

        [HttpDelete]
        public async Task<ActionResult<DeleteIncomeResponseDto>> DeleteIncome([FromBody] DeleteIncomeDto request)
        {
            var response = await _incomeService.DeleteIncome(request.IncomeId, request.HouseholdId);
            if (response.Result != DeleteIncomeResultStatus.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

    }
}
