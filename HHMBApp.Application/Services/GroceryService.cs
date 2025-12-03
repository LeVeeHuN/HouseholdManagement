using HHMBApp.Application.DTOs.Grocery;
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
    public class GroceryService : IGroceryService
    {
        private readonly IGroceryListRepository _groceryListRepository;
        private readonly IGroceryListItemRepository _groceryListItemRepository;

        public GroceryService(IGroceryListRepository groceryListRepository, IGroceryListItemRepository groceryListItemRepository)
        {
            _groceryListRepository = groceryListRepository;
            _groceryListItemRepository = groceryListItemRepository;
        }

        public async Task<CreateGroceryListItemResponseDto> AddItemToGroceryList(CreateGroceryListItemDto request)
        {
            // Check if grocery list exists
            var groceryList = await _groceryListRepository.Read(request.GroceryListId);
            if (groceryList == null)
            {
                return new CreateGroceryListItemResponseDto
                {
                    Id = Guid.Empty,
                    Status = CreateGroceryListItemStatus.CreateGroceryListItemError,
                    Completed = false,
                    GroceryListId = request.GroceryListId,
                    Title = request.Title,
                    Description = request.Description
                };
            }

            // Create new grocery list item
            GroceryListItem newItem = new GroceryListItem
            {
                Id = Guid.NewGuid(),
                GroceryListId = request.GroceryListId,
                Title = request.Title,
                Description = request.Description,
                Completed = false
            };

            await _groceryListItemRepository.Create(newItem);

            return new CreateGroceryListItemResponseDto
            {
                Id = newItem.Id,
                Status = CreateGroceryListItemStatus.OK,
                Completed = newItem.Completed,
                GroceryListId = newItem.GroceryListId,
                Title = newItem.Title,
                Description = newItem.Description
            };
        }

        public async Task<CreateGroceryListResponseDto> CreateGroceryList(CreateGroceryListDto request)
        {
            GroceryList newList = new GroceryList
            {
                Id = Guid.NewGuid(),
                Title = request.Name,
                Description = request.Description,
                HouseholdId = request.HouseholdId
            };

            GroceryList createdList = await _groceryListRepository.Create(newList);

            return new CreateGroceryListResponseDto
            {
                Id = createdList.Id,
                Response = CreateGroceryListResult.OK,
                Name = createdList.Title,
                Description = createdList.Description,
                HouseholdId = createdList.HouseholdId
            };
        }

        public async Task<DeleteGroceryListResponseDto> DeleteGroceryList(Guid groceryListId, Guid householdId)
        {
            // Check if grocery list exists and belongs to the household
            GroceryList? groceryList = await _groceryListRepository.Read(groceryListId);

            if (groceryList == null || groceryList.HouseholdId != householdId)
            {
                return new DeleteGroceryListResponseDto
                {
                    Result = DeleteGroceryListStatus.DeleteGroceryListError,
                    GroceryListId = groceryListId
                };
            }

            // It exists, proceed to delete every item related to the grocery list
            var result = await _groceryListItemRepository.ReadAll();
            List<GroceryListItem> items = result.Where(i => i.GroceryListId == groceryListId).ToList();
            foreach (var item in items)
            {
                await _groceryListItemRepository.Delete(item.Id);
            }
            // Now delete the grocery list
            await _groceryListRepository.Delete(groceryListId);

            return new DeleteGroceryListResponseDto
            {
                Result = DeleteGroceryListStatus.OK,
                GroceryListId = groceryListId
            };
        }

        public async Task<DeleteGroceryListItemResponseDto> DeleteGroceryListItem(Guid groceryListItemId, Guid groceryListId)
        {
            // Check if grocery list item exists and belongs to the grocery list
            GroceryListItem? groceryListItem = await _groceryListItemRepository.Read(groceryListItemId);

            if (groceryListItem == null || groceryListItem.GroceryListId != groceryListId)
            {
                return new DeleteGroceryListItemResponseDto
                {
                    Result = DeleteGroceryListItemStatus.DeleteGroceryListItemError,
                    GroceryListItemId = groceryListItemId
                };
            }

            // It exists, proceed to delete the grocery list item
            await _groceryListItemRepository.Delete(groceryListItemId);

            return new DeleteGroceryListItemResponseDto
            {
                Result = DeleteGroceryListItemStatus.OK,
                GroceryListItemId = groceryListItemId
            };

        }

        public async Task<GetGroceryListDto> GetGroceryListsForHousehold(Guid householdId)
        {
            // Get all grocery lists for the household
            // Get all grocery list items
            // Create a list of GroceryListDto and populate it
            // Enumerate through the newly created list and for each grocery list, add the items that belong to it

            var groceryLists = await _groceryListRepository.ReadAll();
            var groceryListsForHousehold = groceryLists.Where(gl => gl.HouseholdId == householdId).ToList();

            var groceryListItems = await _groceryListItemRepository.ReadAll();
            
            List<GroceryListDto> groceryListDtos = new List<GroceryListDto>();
            foreach (var groceryList in groceryListsForHousehold)
            {
                var itemsForList = groceryListItems.Where(gli => gli.GroceryListId == groceryList.Id).ToList();
                GroceryListDto groceryListDto = new GroceryListDto
                {
                    GroceryListId = groceryList.Id,
                    HouseholdId = groceryList.HouseholdId,
                    Items = itemsForList,
                    Completed = itemsForList.All(i => i.Completed)
                };
                groceryListDtos.Add(groceryListDto);
            }

            return new GetGroceryListDto
            {
                HouseholdId = householdId,
                GroceryLists = groceryListDtos
            };
        }

        public async Task<CreateGroceryListItemResponseDto> MarkItemAsCompleted(Guid groceryListItemId, Guid groceryListId)
        {
            // Check if grocery list item exists and belongs to the grocery list
            GroceryListItem? result = await _groceryListItemRepository.Read(groceryListItemId);

            if (result == null || result.GroceryListId != groceryListId)
            {
                return new CreateGroceryListItemResponseDto
                {
                    Id = Guid.Empty,
                    Status = CreateGroceryListItemStatus.UpdateGroceryListItemError,
                    Completed = false,
                    GroceryListId = groceryListId,
                    Title = string.Empty,
                    Description = string.Empty
                };
            }

            // It exists, proceed to mark it as completed
            result.Completed = true;
            await _groceryListItemRepository.Update(result);

            return new CreateGroceryListItemResponseDto
            {
                Id = result.Id,
                Status = CreateGroceryListItemStatus.OK,
                Completed = result.Completed,
                GroceryListId = result.GroceryListId,
                Title = result.Title,
                Description = result.Description
            };
        }

        public async Task<CreateGroceryListResponseDto> UpdateGroceryList(UpdateGroceryListDto request)
        {
            // Check if grocery list exists
            GroceryList? gl = await _groceryListRepository.Read(request.Id);

            if (gl == null)
            {
                return new CreateGroceryListResponseDto
                {
                    Id = Guid.Empty,
                    Response = CreateGroceryListResult.UpdateGroceryListError,
                    Name = request.Name,
                    Description = request.Description,
                    HouseholdId = request.HouseholdId
                };
            }

            // It exists, proceed to update it
            GroceryList updatedGroceryList = new GroceryList
            {
                Id = request.GroceryListId,
                Title = request.Name,
                Description = request.Description,
                HouseholdId = request.HouseholdId
            };

            GroceryList? result = await _groceryListRepository.Update(updatedGroceryList);

            if (result == null)
            {
                return new CreateGroceryListResponseDto
                {
                    Id = request.GroceryListId,
                    Response = CreateGroceryListResult.UpdateGroceryListError,
                    Name = request.Name,
                    Description = request.Description,
                    HouseholdId = request.HouseholdId
                };
            }

            return new CreateGroceryListResponseDto
            {
                Id = result.Id,
                Response = CreateGroceryListResult.OK,
                Name = result.Title,
                Description = result.Description,
                HouseholdId = result.HouseholdId
            };
        }
    }
}
