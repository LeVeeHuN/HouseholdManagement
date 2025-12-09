using HHMBApp.Application.DTOs.Grocery;
using HHMBApp.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HHMBApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class GroceryController : ControllerBase
    {
        private readonly IGroceryService _groceryService;

        public GroceryController(IGroceryService groceryService)
        {
            _groceryService = groceryService;
        }

        [HttpPost]
        public async Task<ActionResult<CreateGroceryListResponseDto>> CreateGroceryList([FromBody] CreateGroceryListDto request)
        {
            var response = await _groceryService.CreateGroceryList(request);

            if (response.Response != CreateGroceryListResult.OK)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<GetGroceryListDto>> GetGroceryListsForHousehold([FromQuery] Guid householdId)
        {
            var response = await _groceryService.GetGroceryListsForHousehold(householdId);
            return Ok(response);
        }

        [HttpPost("additem")]
        public async Task<ActionResult<CreateGroceryListItemResponseDto>> AddItemToGroceryList([FromBody] CreateGroceryListItemDto request)
        {
            var response = await _groceryService.AddItemToGroceryList(request);
            if (response.Status != CreateGroceryListItemStatus.OK)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<CreateGroceryListResponseDto>> UpdateGroceryList([FromBody] UpdateGroceryListDto request)
        {
            var response = await _groceryService.UpdateGroceryList(request);
            if (response.Response != CreateGroceryListResult.OK)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult<DeleteGroceryListResponseDto>> DeleteGroceryList([FromQuery] Guid groceryListId, [FromQuery] Guid householdId)
        {
            var response = await _groceryService.DeleteGroceryList(groceryListId, householdId);
            if (response.Result != DeleteGroceryListStatus.OK)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpDelete("deleteitem")]
        public async Task<ActionResult<DeleteGroceryListItemResponseDto>> DeleteGroceryListItem([FromQuery] Guid groceryListItemId, [FromQuery] Guid groceryListId)
        {
            var response = await _groceryService.DeleteGroceryListItem(groceryListItemId, groceryListId);
            if (response.Result != DeleteGroceryListItemStatus.OK)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("markcompleted")]
        public async Task<ActionResult<CreateGroceryListItemResponseDto>> MarkItemAsCompleted([FromQuery] Guid groceryListItemId, [FromQuery] Guid groceryListId)
        {
            var response = await _groceryService.MarkItemAsCompleted(groceryListItemId, groceryListId);
            if (response.Status != CreateGroceryListItemStatus.OK)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
