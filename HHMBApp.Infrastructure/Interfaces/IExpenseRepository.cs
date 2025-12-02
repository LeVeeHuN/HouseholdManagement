using HHMBApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHMBApp.Infrastructure.Interfaces
{
    public interface IExpenseRepository
    {
        Task<Expense?> Create(Expense expense);
        Task<Expense?> Read(Guid id);
        Task<IEnumerable<Expense>> ReadAll();
        Task<Expense?> Update(Expense expense);
        Task<Expense?> Delete(Guid id);
    }
}
