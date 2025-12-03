using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHMBApp.Application.DTOs.Grocery
{
    public class CreateGroceryListDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public Guid HouseholdId { get; set; }
    }
}
