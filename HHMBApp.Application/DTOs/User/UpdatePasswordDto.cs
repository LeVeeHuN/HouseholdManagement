using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHMBApp.Application.DTOs.User
{
    public class UpdatePasswordDto
    {
        public Guid UserId {  get; set; }
        public string OldPassword { get; set; } = null!;
        public string NewPassword { get; set; } = null!;
    }

    public class UpdatePasswordResponseDto
    {
        public Guid? UserId { get; set; }
        public UpdatePasswordStatus Result { get; set; }
    }

    public enum UpdatePasswordStatus
    {
        OK = 0,
        UserNotFound = 1,
        PasswordMismatch = 2
    }
}
