using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHMBApp.Application.DTOs.User
{
    public class CreateUserResponseDto
    {
        public CreateUserResult Result { get; set; }
        public Guid Id {  get; set; }
        public string? Username { get; set; }
    }

    public enum CreateUserResult
    {
        OK = 0,
        UsernameTaken = 1,
        UsernameError = 2,
        UserCreateError = 3
    }
}
