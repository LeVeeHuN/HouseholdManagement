using HHMBApp.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace HHMBApp.Maui.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        private readonly IAuthService _authService;

        public UserService(HttpClient httpClient, IAuthService authService)
        {
            _httpClient = httpClient;
            _authService = authService;
        }

        public async Task<GetHouseholdIdDto?> GetHouseholdIdAsync()
        {
            var userId = await _authService.GetUserIdAsync();

            if (userId == null || userId == Guid.Empty)
            {
                return null;
            }

            var url = $"user/gethouseholdid?userId={userId.ToString()}";

            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            return await response.Content.ReadFromJsonAsync<GetHouseholdIdDto>();
        }
    }
}
