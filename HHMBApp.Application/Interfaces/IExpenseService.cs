using HHMBApp.Application.DTOs.Expense;
using HHMBApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHMBApp.Application.Interfaces
{
    public interface IExpenseService
    {
        Task<CreateExpenseResponseDto> CreateIncome(CreateExpenseDto request);
        Task<CreateExpenseResponseDto> UpdateIncome(UpdateExpenseDto request);
        Task<IEnumerable<Income>> ReadIncomes(Guid householdId);
        Task<DeleteExpenseResponseDto> DeleteIncome(Guid id, Guid householdId);
    }
}
