using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HHMBApp.Maui.Helpers;
using HHMBApp.Maui.Services;
using HHMBApp.Maui.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHMBApp.Maui.ViewModels
{
    public partial class StartupViewModel : ObservableObject
    {
        private readonly IAuthService _authService;

        public StartupViewModel(IAuthService authService)
        {
            _authService = authService;
        }

        [ObservableProperty]
        private string status = "Checking session...";

        public async Task InitializeAsync()
        {
            var isAuth = await _authService.IsAuthenticatedAsync();

            if (isAuth)
            {
                // go to home
                Microsoft.Maui.Controls.Application.Current.MainPage = new AppShell();
            }
            else
            {
                // go to login
                Microsoft.Maui.Controls.Application.Current.MainPage = ServiceHelper.GetService<LoginPage>();
            }
        }
    }
}
