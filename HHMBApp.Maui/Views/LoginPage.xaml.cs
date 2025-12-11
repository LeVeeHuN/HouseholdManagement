using HHMBApp.Maui.ViewModels;

namespace HHMBApp.Maui.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
    }
}