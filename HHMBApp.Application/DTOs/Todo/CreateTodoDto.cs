using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHMBApp.Application.DTOs.Todo
{
    public class CreateTodoDto
    {
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? DeadLine { get; set; }
        public Guid CreatedByUserId { get; set; }
        public Guid AssignedToUserId { get; set; }
        public Guid ClosedByUserId { get; set; }
        public DateTime? ClosedAt { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public Guid HouseholdId { get; set; }
    }
}
