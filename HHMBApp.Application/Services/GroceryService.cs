using HHMBApp.Application.DTOs.Grocery;
using HHMBApp.Application.Interfaces;
using HHMBApp.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHMBApp.Application.Services
{
    public class GroceryService : IGroceryService
    {
        private readonly IGroceryListRepository _groceryListRepository;
        private readonly IGroceryListItemRepository _groceryListItemRepository;

        public GroceryService(IGroceryListRepository groceryListRepository, IGroceryListItemRepository groceryListItemRepository)
        {
            _groceryListRepository = groceryListRepository;
            _groceryListItemRepository = groceryListItemRepository;
        }

        public Task<CreateGroceryListItemResponseDto> AddItemToGroceryList(CreateGroceryListItemDto request)
        {
            throw new NotImplementedException();
        }

        public Task<CreateGroceryListResponseDto> CreateGroceryList(CreateGroceryListDto request)
        {
            throw new NotImplementedException();
        }

        public Task<DeleteGroceryListResponseDto> DeleteGroceryList(Guid groceryListId, Guid householdId)
        {
            throw new NotImplementedException();
        }

        public Task<DeleteGroceryListItemResponseDto> DeleteGroceryListItem(Guid groceryListItemId, Guid groceryListId)
        {
            throw new NotImplementedException();
        }

        public Task<GetGroceryListDto> GetGroceryListsForHousehold(Guid householdId)
        {
            throw new NotImplementedException();
        }

        public Task<CreateGroceryListItemResponseDto> MarkItemAsCompleted(Guid groceryListItemId, Guid groceryListId)
        {
            throw new NotImplementedException();
        }

        public Task<CreateGroceryListResponseDto> UpdateGroceryList(UpdateGroceryListDto request)
        {
            throw new NotImplementedException();
        }
    }
}
