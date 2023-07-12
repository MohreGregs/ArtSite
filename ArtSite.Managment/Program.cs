using System;
using System.Diagnostics;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Platform;
using Avalonia.ReactiveUI;
using Nein.Extensions;
using Splat;

namespace ArtSite.Managment {
    class Program {
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        [STAThread]
        public static void Main(string[] args)
        {
            try
            {
                var builder = BuildAvaloniaApp();

                Register(Locator.CurrentMutable, Locator.Current, builder.RuntimePlatform);

                builder.StartWithClassicDesktopLifetime(args);
            }
            catch (Exception ex) //If we have an unhandled exception we catch it here
            {
#if DEBUG
                // If we debug the application and an unhandled exception is thrown,
                // we need to initiate a break for the debugger, so we can debug the exception.
                // Because we handle it above, the application just closes and logs it.
                // This avoids opening the logs and we can debug it directly.
                Debugger.Break();
#endif
            }
        }
        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp() {
            return AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToTrace()
                .UseSkia()
                .UseReactiveUI()
                .With(new Win32PlatformOptions
                {
                    AllowEglInitialization = true,
                    UseWindowsUIComposition = true
                });
        }
        
        private static void Register(IMutableDependencyResolver services, IReadonlyDependencyResolver resolver, IRuntimePlatform platform)
        {
            services.Register(() => new MainWindowViewModel());
            
            services.RegisterLazySingleton(() => new MainWindow(
                resolver.GetRequiredService<MainWindowViewModel>()));
        } 
    }
}