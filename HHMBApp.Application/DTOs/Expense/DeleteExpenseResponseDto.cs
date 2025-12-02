using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHMBApp.Application.DTOs.Expense
{
    public class DeleteExpenseResponseDto
    {
        public Guid Id { get; set; }
        public DeleteExpenseResponseStatus Response { get; set; }
    }

    public enum DeleteExpenseResponseStatus
    {
        OK,
        DeleteExpenseError
    }
}
