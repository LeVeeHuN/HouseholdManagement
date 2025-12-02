using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHMBApp.Application.DTOs.User
{
    public class CreateUserDto
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
