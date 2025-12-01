using HHMBApp.Domain.Entities;

namespace HHMBApp.Application.Interfaces;

public interface IJwtTokenService
{
    string GenerateToken(User user);
}