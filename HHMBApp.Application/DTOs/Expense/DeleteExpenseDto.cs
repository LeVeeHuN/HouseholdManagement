using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHMBApp.Application.DTOs.Expense
{
    public class DeleteExpenseDto
    {
        public Guid ExpenseId { get; set; }
        public Guid HouseholdId { get; set; }
    }
}
