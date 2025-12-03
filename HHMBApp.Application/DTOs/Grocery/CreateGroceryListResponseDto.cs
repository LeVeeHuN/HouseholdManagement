using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHMBApp.Application.DTOs.Grocery
{
    public class CreateGroceryListResponseDto : CreateGroceryListDto
    {
        public Guid Id { get; set; }
        public CreateGroceryListResult Response { get; set; }
    }

    public enum CreateGroceryListResult
    {
        OK,
        CreateGroceryListError,
        UpdateGroceryListError
    }
}
