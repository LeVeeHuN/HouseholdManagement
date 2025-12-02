using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHMBApp.Application.DTOs.Expense
{
    public class CreateExpenseResponseDto : UpdateExpenseDto
    {
        public CreateExpenseResponseStatus Response { get; set; }
    }

    public enum CreateExpenseResponseStatus
    {
        OK,
        CreateExpenseError,
        UpdateExpenseError
    }
}
