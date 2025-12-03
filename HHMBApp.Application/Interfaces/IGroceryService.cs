using HHMBApp.Application.DTOs.Grocery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHMBApp.Application.Interfaces
{
    public interface IGroceryService
    {
        Task<CreateGroceryListResponseDto> CreateGroceryList(CreateGroceryListDto request);
        Task<GetGroceryListDto> GetGroceryListsForHousehold(Guid householdId);
        Task<CreateGroceryListItemResponseDto> AddItemToGroceryList(CreateGroceryListItemDto request);
        Task<CreateGroceryListResponseDto> UpdateGroceryList(UpdateGroceryListDto request);
        Task<DeleteGroceryListResponseDto> DeleteGroceryList(Guid groceryListId, Guid householdId);
        Task<DeleteGroceryListItemResponseDto> DeleteGroceryListItem(Guid groceryListItemId, Guid groceryListId);
        Task<CreateGroceryListItemResponseDto> MarkItemAsCompleted(Guid groceryListItemId, Guid groceryListId);
    }
}
