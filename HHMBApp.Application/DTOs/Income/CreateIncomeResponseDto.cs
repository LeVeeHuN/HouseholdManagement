using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHMBApp.Application.DTOs.Income
{
    public class CreateIncomeResponseDto
    {
        public Guid Id { get; set; }
        public Guid HoueseholdId { get; set; }
        public Guid UserId { get; set; }
        public Guid CategoryId { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public CreateIncomeResultStatus Result { get; set; }
    }

    public enum CreateIncomeResultStatus
    {
        Success,
        IncomeCreateError,
        UpdateIncomeError
    }
}
