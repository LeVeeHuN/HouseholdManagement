using HHMBApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHMBApp.Infrastructure.Interfaces
{
    public interface IGroceryListRepository
    {
        Task<GroceryList> Create(GroceryList groceryList);
        Task<GroceryList?> Read(Guid id);
        Task<IEnumerable<GroceryList>> ReadAll();
        Task<GroceryList?> Update(GroceryList groceryList);
        Task<GroceryList?> Delete(Guid id);
    }
}
