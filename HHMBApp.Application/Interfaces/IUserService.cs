using HHMBApp.Application.DTOs;
using HHMBApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHMBApp.Application.Interfaces
{
    public interface IUserService
    {
        Task<User?> GetUser(Guid userId);
        Task<User?> GetUser(string username);
        Task<User?> AddUser(CreateUserDto createUserDto);
        Task<bool> UpdatePassword(UpdatePasswordDto updatePasswordDto);
        Task<bool> Login(string username, string password);
    }
}
