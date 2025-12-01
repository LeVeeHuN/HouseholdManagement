using HHMBApp.Application.DTOs;
using HHMBApp.Application.Interfaces;
using HHMBApp.Domain.Entities;
using HHMBApp.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HHMBApp.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository = null!;
        private readonly PasswordHasher<User> _passwordHasher = new PasswordHasher<User>();

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<CreateUserResponseDto> AddUser(CreateUserDto createUserDto)
        {
            // Normalize username (remove whitespaces)
            createUserDto.Username = Regex.Replace(createUserDto.Username, @"\s+", string.Empty);
            if (createUserDto.Username.Length < 1)
                return new CreateUserResponseDto()
                {
                    Result = CreateUserResult.UsernameError,
                    Id = null,
                    Username = null
                };
            // Check if the username is already taken or not
            if (_userRepository.ReadUser(createUserDto.Username) == null)
            {
                return new CreateUserResponseDto()
                {
                    Result = CreateUserResult.UsernameTaken,
                    Id = null,
                    Username = null
                };
            }
            // TODO Create new user and hash the password

        }

        public Task<User?> GetUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetUser(string username)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatePassword(UpdatePasswordDto updatePasswordDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Login(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
