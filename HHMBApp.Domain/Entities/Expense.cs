using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHMBApp.Domain.Entities
{
    public class Expense
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid HouseholdId { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        public Guid CategoryId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? ReceiptBase64 { get; set; }
    }
}
