using HHMBApp.Application.DTOs.Household;
using HHMBApp.Application.Interfaces;
using HHMBApp.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HHMBApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class HouseholdController : ControllerBase
    {
        private readonly IHouseholdService _householdService;

        public HouseholdController(IHouseholdService householdService)
        {
            _householdService = householdService;
        }

        [HttpGet]
        public async Task<ActionResult<Household?>> GetHousehold([FromQuery] Guid householdId)
        {
            if (householdId == Guid.Empty)
            {
                return BadRequest();
            }

            var household = await _householdService.GetHouseholdById(householdId);
            if (household == null)
            {
                return NotFound();
            }

            return Ok(household);
        }

        [HttpPost]
        public async Task<ActionResult<Household>> CreateHousehold([FromBody] CreateHouseholdRequestDto request)
        {
            var result = await _householdService.CreateHousehold(request.HouseholdName);
            return Ok(result);
        }

        [HttpPatch]
        public async Task<ActionResult<UpdateHouseholdResponseDto>> ChangeHouseholdName([FromQuery] Guid householdId, [FromBody] ChangeNameRequestDto request)
        {
            var result = await _householdService.ChangeHouseholdName(householdId, request.NewName);

            return result != null ? Ok(result) : NotFound();
        }
    }
}
