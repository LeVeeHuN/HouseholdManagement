using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHMBApp.Application.DTOs.Expense
{
    public class CreateExpenseDto
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public Guid CategoryId { get; set; }
        public Guid UserId { get; set; }
        public Guid HouseholdId { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow; // If no date is provided, use current date
        public string? ReceiptBase64 { get; set; }
    }
}
