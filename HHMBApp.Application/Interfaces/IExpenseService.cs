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
        Task<CreateExpenseResponseDto> CreateExpense(CreateExpenseDto request);
        Task<CreateExpenseResponseDto> UpdateExpense(UpdateExpenseDto request);
        Task<IEnumerable<Expense>> ReadExpenses(Guid householdId);
        Task<DeleteExpenseResponseDto> DeleteExpense(Guid id, Guid householdId);
    }
}
