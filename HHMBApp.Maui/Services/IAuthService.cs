using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHMBApp.Maui.Services
{
    public interface IAuthService
    {
        Task<bool> LoginAsync(string username, string password);
        Task LogoutAsync();

        Task<string?> GetTokenAsync();
        Task<DateTimeOffset?> GetTokenExpiryAsync();
        Task<bool> IsAuthenticatedAsync();
        Task<Guid> GetUserIdAsync();
    }
}
