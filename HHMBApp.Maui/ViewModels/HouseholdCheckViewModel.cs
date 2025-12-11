using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HHMBApp.Maui.Helpers;
using HHMBApp.Maui.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHMBApp.Maui.ViewModels
{
    public partial class HouseholdCheckViewModel : ObservableObject
    {
        private readonly IUserService _userService;

        public HouseholdCheckViewModel(IUserService userService)
        {
            _userService = userService;
        }

        [ObservableProperty]
        private string status = "Checking household...";

        [RelayCommand]
        public async Task InitializeAsync()
        {
            var dto = await _userService.GetHouseholdIdAsync();

            if (dto == null)
            {
                Status = "Error checking household.";
                return;
            }

            if (dto.HouseholdId != null && dto.HouseholdId != Guid.Empty)
            {
                Microsoft.Maui.Controls.Application.Current.MainPage = new AppShell();
            }
            else
            {
                Microsoft.Maui.Controls.Application.Current.MainPage = ServiceHelper.GetService<CreateHouseholdPage>();
            }
        }
    }
}
