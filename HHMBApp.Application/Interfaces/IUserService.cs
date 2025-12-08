using HHMBApp.Application.DTOs.User;
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
        Task<User?> GetUser(GetUserDto request);
        Task<CreateUserResponseDto> AddUser(CreateUserDto createUserDto);
        Task<UpdatePasswordResponseDto> UpdatePassword(UpdatePasswordDto updatePasswordDto);
        Task<LoginResponseDto> Login(LoginRequestDto loginRequest);
        Task<IEnumerable<User>> GetUsersFromHousehold(Guid householdId);
        Task<User?> JoinHousehold(JoinUserHouseholdDto request);
    }
}
