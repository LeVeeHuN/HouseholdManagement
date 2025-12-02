using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHMBApp.Application.DTOs
{
    public class DeleteIncomeResponseDto
    {
        public Guid Id { get; set; }
        public DeleteIncomeResultStatus Result { get; set; }
    }

    public enum DeleteIncomeResultStatus
    {
        Success,
        IncomeDeleteError
    }
}
