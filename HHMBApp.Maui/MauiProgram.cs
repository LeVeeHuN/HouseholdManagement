using HHMBApp.Maui.Helpers;
using HHMBApp.Maui.Services;
using HHMBApp.Maui.ViewModels;
using HHMBApp.Maui.Views;
using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;

namespace HHMBApp.Maui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddHttpClient<IAuthService, AuthService>(client =>
            {
                client.BaseAddress = new Uri("http://localhost:5000/api/");
            });
            builder.Services.AddTransient<StartupViewModel>();
            builder.Services.AddTransient<StartupPage>();
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddHttpClient<IUserService, UserService>(client =>
            {
                client.BaseAddress = new Uri("http://localhost:5000/api/");
            });
            builder.Services.AddTransient<HouseholdCheckViewModel>();
            builder.Services.AddTransient<HouseholdCheckPage>();


            var app = builder.Build();
            ServiceHelper.Initialize(app.Services);
            return app;
        }
    }
}
