using HHMBApp.Maui.ViewModels;

namespace HHMBApp.Maui.Views;

public partial class StartupPage : ContentPage
{
	private readonly StartupViewModel _viewModel;

    public StartupPage(StartupViewModel viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;
    }

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		await _viewModel.InitializeAsync();
    }
}