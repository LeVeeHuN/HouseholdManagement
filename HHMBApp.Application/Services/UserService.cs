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
using BCrypt.Net;

namespace HHMBApp.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository = null!;
        private readonly IJwtTokenService _jwtTokenService = null!;

        public UserService(IUserRepository userRepository, IJwtTokenService jwtTokenService)
        {
            _userRepository = userRepository;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<CreateUserResponseDto> AddUser(CreateUserDto createUserDto)
        {
            // Normalize username (remove whitespaces)
            createUserDto.Username = Regex.Replace(createUserDto.Username, @"\s+", string.Empty);
            if (createUserDto.Username.Length < 1)
                return new CreateUserResponseDto()
                {
                    Result = CreateUserResult.UsernameError,
                    Id = Guid.Empty,
                    Username = null
                };
            // Check if the username is already taken or not
            if (await _userRepository.ReadUser(createUserDto.Username) == null)
            {
                return new CreateUserResponseDto()
                {
                    Result = CreateUserResult.UsernameTaken,
                    Id = Guid.Empty,
                    Username = null
                };
            }
            
            User? newUser = await _userRepository.CreateUser(new User(){Id = Guid.NewGuid(), Username = createUserDto.Username, Password = BCrypt.Net.BCrypt.HashPassword(createUserDto.Password)});

            if (newUser == null)
            {
                return new CreateUserResponseDto()
                {
                    Result = CreateUserResult.UserCreateError,
                    Id = Guid.Empty,
                    Username = null
                };
            }

            return new CreateUserResponseDto()
            {
                Result = CreateUserResult.OK,
                Id = newUser.Id,
                Username = newUser.Username,
            };
        }

        public async Task<User?> GetUser(Guid userId)
        {
            return await _userRepository.ReadUser(userId);
        }

        public async Task<User?> GetUser(string username)
        {
            return await _userRepository.ReadUser(username);
        }

        public async Task<UpdatePasswordResponseDto> UpdatePassword(UpdatePasswordDto updatePasswordDto)
        {
            // Find the user, check if password is OK, then change it
            User? userToChangePassword = await GetUser(updatePasswordDto.UserId);
            if (userToChangePassword == null)
            {
                return new UpdatePasswordResponseDto()
                {
                    UserId = null,
                    Result = UpdatePasswordStatus.UserNotFound
                };
            }
            
            // Check password
            bool passwordOk = BCrypt.Net.BCrypt.Verify(updatePasswordDto.OldPassword, userToChangePassword.Password);

            if (!passwordOk)
            {
                return new UpdatePasswordResponseDto()
                {
                    UserId = userToChangePassword.Id,
                    Result = UpdatePasswordStatus.UserNotFound
                };
            }
            
            userToChangePassword.Password = BCrypt.Net.BCrypt.HashPassword(updatePasswordDto.NewPassword);
            User? updatedUser = await _userRepository.UpdateUser(userToChangePassword); // Won't be null

            return new UpdatePasswordResponseDto()
            {
                UserId = updatedUser.Id,
                Result = UpdatePasswordStatus.OK
            };
        }

        public async Task<LoginResponseDto> Login(string username, string password)
        {
            // Check credentials, and if OK generate a JWT token
            User? userToLogin = await GetUser(username);

            if (userToLogin == null)
            {
                return new LoginResponseDto()
                {
                    JwtToken = null,
                    UserId = Guid.Empty,
                    Result = LoginResponseStatus.LoginError
                };
            }
            
            // Check password
            bool passwordOk = BCrypt.Net.BCrypt.Verify(password, userToLogin.Password);

            if (!passwordOk)
            {
                return new LoginResponseDto()
                {
                    JwtToken = null,
                    UserId = userToLogin.Id,
                    Result = LoginResponseStatus.LoginError
                };
            }
            
            // Password OK
            return new LoginResponseDto()
            {
                JwtToken = _jwtTokenService.GenerateToken(userToLogin),
                UserId = userToLogin.Id,
                Result = LoginResponseStatus.OK
            };
        }
    }
}
