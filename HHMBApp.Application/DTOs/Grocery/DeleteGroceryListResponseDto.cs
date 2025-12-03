using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHMBApp.Application.DTOs.Grocery
{
    public class DeleteGroceryListResponseDto
    {
        public Guid GroceryListId { get; set; }
        public DeleteGroceryListStatus Result { get; set; }
    }

    public enum DeleteGroceryListStatus
    {
        OK = 0,
        DeleteGroceryListError = 1
    }
}
