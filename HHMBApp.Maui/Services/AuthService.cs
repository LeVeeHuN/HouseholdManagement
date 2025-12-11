using HHMBApp.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace HHMBApp.Maui.Services
{
    public class AuthService : IAuthService
    {
        private const string TokenKey = "auth_token";
        private const string TokenExpiryKey = "auth_token_expiry";
        private const string UserIdKey = "auth_user_id";

        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string?> GetTokenAsync()
        {
            return await SecureStorage.GetAsync(TokenKey);
        }

        public async Task<DateTimeOffset?> GetTokenExpiryAsync()
        {
            var raw = await SecureStorage.GetAsync(TokenExpiryKey);
            if (long.TryParse(raw, out var unix))
            {
                return DateTimeOffset.FromUnixTimeSeconds(unix);
            }
            return null;
        }

        public async Task<Guid> GetUserIdAsync()
        {
            var uid = await SecureStorage.GetAsync(UserIdKey);
            if (uid == null || string.IsNullOrWhiteSpace(uid))
            {
                return Guid.Empty;
            }
            return Guid.Parse(uid);
        }

        public async Task<bool> IsAuthenticatedAsync()
        {
            var token = await GetTokenAsync();
            if (token == null || string.IsNullOrWhiteSpace(token))
            {
                return false;
            }

            var expiry = await GetTokenExpiryAsync();
            if (expiry == null)
            {
                return false;
            }

            return expiry > DateTimeOffset.UtcNow;
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            var request = new LoginRequestDto { Username = username, Password = password };

            var response = await _httpClient.PostAsJsonAsync("auth/login", request);
            if (!response.IsSuccessStatusCode)
            {
                return false;
            }

            var result = await response.Content.ReadFromJsonAsync<LoginResponseDto>();
            if (result == null || string.IsNullOrWhiteSpace(result.JwtToken) || result.Result != LoginResponseStatus.OK)
            {
                return false;
            }

            var expiresAt = DateTimeOffset.UtcNow.AddMinutes(59);

            await SecureStorage.SetAsync(TokenKey, result.JwtToken);
            await SecureStorage.SetAsync(TokenExpiryKey, expiresAt.ToUnixTimeSeconds().ToString());
            await SecureStorage.SetAsync(UserIdKey, result.UserId.ToString());

            return true;
        }

        public async Task LogoutAsync()
        {
            SecureStorage.Remove(TokenKey);
            SecureStorage.Remove(UserIdKey);
            SecureStorage.Remove(TokenExpiryKey);
            await Task.CompletedTask;
        }
    }
}
