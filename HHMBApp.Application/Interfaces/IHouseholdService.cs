using HHMBApp.Application.DTOs.Household;
using HHMBApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHMBApp.Application.Interfaces
{
    public interface IHouseholdService
    {
        Task<Household> CreateHousehold(string name);
        Task<Household?> GetHouseholdById(Guid id);
        Task<UpdateHouseholdResponseDto> ChangeHouseholdName(Guid householdId, string newName);
    }
}
