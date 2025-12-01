using HHMBApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHMBApp.Infrastructure.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> CreateUser(User user);
        Task<User?> UpdateUser(User user);
        Task<User?> ReadUser(Guid id);
        Task<User?> ReadUser(string username);
    }
}
