using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HHMBApp.Maui.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHMBApp.Maui.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly IAuthService _authService;

        public LoginViewModel(IAuthService authService)
        {
            _authService = authService;
        }

        [ObservableProperty]
        private string username = string.Empty;

        [ObservableProperty]
        private string password = string.Empty;

        [ObservableProperty]
        private bool isBusy;

        [ObservableProperty]
        private string errorMessage = string.Empty;

        [RelayCommand]
        private async Task LoginAsync()
        {
            if (IsBusy)
            {
                return;
            }

            try
            {
                IsBusy = true;
                ErrorMessage = string.Empty;

                var success = await _authService.LoginAsync(Username, Password);
                if (!success)
                {
                    ErrorMessage = "Invalid username or password.";
                    return;
                }

                // Replace UI
                Microsoft.Maui.Controls.Application.Current.MainPage = new AppShell();
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
