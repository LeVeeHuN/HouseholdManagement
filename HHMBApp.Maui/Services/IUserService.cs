using HHMBApp.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHMBApp.Maui.Services
{
    public interface IUserService
    {
        Task<GetHouseholdIdDto?> GetHouseholdIdAsync();
    }
}
