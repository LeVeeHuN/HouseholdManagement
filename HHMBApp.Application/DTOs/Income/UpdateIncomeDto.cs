using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHMBApp.Application.DTOs.Income
{
    public class UpdateIncomeDto : CreateIncomeDto
    {
        public Guid Id { get; set; }
    }
}
