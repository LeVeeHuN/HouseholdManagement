using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHMBApp.Application.DTOs.Grocery
{
    public class DeleteGroceryListItemResponseDto
    {
        public Guid GroceryListItemId { get; set; }
        public DeleteGroceryListItemStatus Result { get; set; }
    }

    public enum DeleteGroceryListItemStatus
    {
        OK = 0,
        DeleteGroceryListItemError = 1
    }
}
