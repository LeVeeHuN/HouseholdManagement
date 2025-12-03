using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHMBApp.Domain.Entities
{
    public class GroceryListItem
    {
        [Key]
        public Guid Id { get; set; }
        public Guid GroceryListId { get; set; }
        public bool Completed { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
    }
}
