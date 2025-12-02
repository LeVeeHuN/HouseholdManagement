using HHMBApp.Application.DTOs;
using HHMBApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHMBApp.Application.Interfaces
{
    public interface IIncomeService
    {
        Task<CreateIncomeResponseDto> CreateIncome(CreateIncomeDto request);
        Task<CreateIncomeResponseDto> UpdateIncome(UpdateIncomeDto request);
        Task<IEnumerable<Income>> ReadIncomes(Guid householdId);
        Task<DeleteIncomeResponseDto> DeleteIncome(Guid id, Guid householdId);
    }
}
