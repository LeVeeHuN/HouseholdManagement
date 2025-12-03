using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHMBApp.Application.DTOs.Household
{
    public class UpdateHouseholdResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string JoinCode { get; set; } = null!;
        public UpdateHouseholdStatus Response { get; set; }
    }

    public enum UpdateHouseholdStatus
    {
        OK = 0,
        UpdateHouseholdError = 1,
    }
}
