using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHMBApp.Application.DTOs.Expense
{
    public class UpdateExpenseDto : CreateExpenseDto
    {
        public Guid Id { get; set; }
    }
}
