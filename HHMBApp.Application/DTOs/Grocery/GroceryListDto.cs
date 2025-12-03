using HHMBApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHMBApp.Application.DTOs.Grocery
{
    public class GetGroceryListDto
    {
        public Guid HouseholdId { get; set; }
        public IEnumerable<GroceryListDto> GroceryLists { get; set; } = null!;
    }

    public class GroceryListDto
    {
        public Guid GroceryListId { get; set; }
        public Guid HouseholdId { get; set; }
        public IEnumerable<GroceryListItem> Items { get; set; } = null!;
        public bool Completed { get; set; }
    }
}
