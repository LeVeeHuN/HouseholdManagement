using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHMBApp.Domain.Entities
{
    public class GroceryList
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public Guid HouseholdId { get; set; }
    }
}
