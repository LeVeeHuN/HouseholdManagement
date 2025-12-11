using HHMBApp.Maui.Views;

namespace HHMBApp.Maui
{
    public partial class App : Microsoft.Maui.Controls.Application
    {
        public App(StartupPage startupPage)
        {
            InitializeComponent();
            MainPage = startupPage;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}