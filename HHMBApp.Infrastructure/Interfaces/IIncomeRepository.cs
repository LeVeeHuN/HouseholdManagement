using HHMBApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHMBApp.Infrastructure.Interfaces
{
    public interface IIncomeRepository
    {
        Task<Income?> Create(Income income);
        Task<Income?> Read(Guid id);
        Task<IEnumerable<Income>> ReadAll();
        Task<Income?> Update(Income income);
        Task<Income?> Delete(Guid id);
    }
}
