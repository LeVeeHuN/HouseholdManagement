using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHMBApp.Domain.Entities
{
    public class Wish
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ClosedAt { get; set; }
        public Guid CreatedByUserId { get; set; }
        public Guid ClosedByUserId { get; set; }
        public int ApproxAmount { get; set; }
        public Guid HouseholdId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
    }
}
