using HHMBApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHMBApp.Infrastructure.Interfaces
{
    public interface IGroceryListItemRepository
    {
        Task<GroceryListItem> Create(GroceryListItem groceryListItem);
        Task<GroceryListItem?> Read(Guid id);
        Task<IEnumerable<GroceryListItem>> ReadAll();
        Task<GroceryListItem?> Update(GroceryListItem groceryListItem);
        Task<GroceryListItem?> Delete(Guid id);
    }
}
