using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHMBApp.Application.DTOs.Income
{
    public class CreateIncomeDto
    {
        public Guid HoueseholdId { get; set; }
        public Guid UserId { get; set; }
        public Guid CategoryId { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow; // If no date is provided, use current date
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
