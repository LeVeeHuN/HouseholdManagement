using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHMBApp.Application.DTOs.Grocery
{
    public class UpdateGroceryListDto : CreateGroceryListDto
    {
        public Guid GroceryListId { get; set; }
    }
}
