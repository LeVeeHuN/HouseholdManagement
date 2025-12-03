using HHMBApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHMBApp.Infrastructure.Interfaces
{
    public interface IHouseholdRepository
    {
        Task<Household> Create(Household household);
        Task<Household?> Read(Guid id);
        Task<IEnumerable<Household>> ReadAll();
        Task<Household?> Update(Household household);
        Task<Household?> Delete(Guid id);
    }
}
