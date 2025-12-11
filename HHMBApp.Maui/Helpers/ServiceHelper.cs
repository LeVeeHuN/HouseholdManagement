using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHMBApp.Maui.Helpers
{
    public static class ServiceHelper
    {
        public static IServiceProvider Services { get; private set; } = null!;

        public static void Initialize(IServiceProvider serviceProvider)
        {
            Services = serviceProvider;
        }

        public static T GetService<T>() where T : class => 
            Services.GetService(typeof(T)) as T
            ?? throw new InvalidOperationException($"Service of type {typeof(T).FullName} not registered.");
    }
}
