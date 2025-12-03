using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHMBApp.Application.DTOs.Grocery
{
    public class CreateGroceryListItemResponseDto : CreateGroceryListItemDto
    {
        public Guid Id { get; set; }
        public CreateGroceryListItemStatus Status { get; set; }
        public bool Completed { get; set; }
    }

    public enum CreateGroceryListItemStatus
    {
        OK = 0,
        CreateGroceryListItemError = 1,
        UpdateGroceryListItemError = 2
    }
}
