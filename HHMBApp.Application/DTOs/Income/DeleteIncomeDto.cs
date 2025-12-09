using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHMBApp.Application.DTOs.Income
{
    public class DeleteIncomeDto
    {
        public Guid IncomeId { get; set; }
        public Guid HouseholdId { get; set; }
    }
}
