using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Platform;
using Avalonia.ReactiveUI;
using Nein.Extensions;
using Splat;

namespace ArtSiteDashboard {
    class Program {
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        [STAThread]
        public static void Main(string[] args) {
            var builder = BuildAvaloniaApp();
            
            //Register(Locator.CurrentMutable, Locator.Current, builder.RuntimePlatform);
            
            builder.StartWithClassicDesktopLifetime(args);
        }

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToTrace()
                .UseReactiveUI()
                .With(new Win32PlatformOptions
                {
                    AllowEglInitialization = true,
                    UseWindowsUIComposition = true
                });

        // private static void Register(IMutableDependencyResolver services, IReadonlyDependencyResolver resolver,
        //     IRuntimePlatform platform) {
        //     services.Register<MainWindowViewModel>(() => new MainWindowViewModel());
        //     services.RegisterLazySingleton(() => new MainWindow(resolver.GetRequiredService<MainWindowViewModel>()));
        //     services.RegisterLazySingleton<IMessenger>(() => new Messenger());
        // }
    }
}