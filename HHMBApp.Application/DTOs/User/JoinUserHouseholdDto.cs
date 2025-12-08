using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHMBApp.Application.DTOs.User
{
    public class JoinUserHouseholdDto
    {
        public Guid UserId { get; set; }
        public Guid HouseholdId { get; set; }
    }
}
