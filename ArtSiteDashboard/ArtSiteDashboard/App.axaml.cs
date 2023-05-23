using System;
using System.ComponentModel;
using ArtSiteDashboard.Views;
using ArtSiteDashboard.Views.CharacterViews;
using ArtSiteDashboard.Windows;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Nein.Extensions;
using ReactiveUI;
using Splat;
using Splat.Microsoft.Extensions.DependencyInjection;

namespace ArtSiteDashboard {
    public partial class App : Application {
        public IServiceProvider Container { get; private set; }
        public IHost host { get; set; }
        public override void Initialize() {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted() {
            host = Host.CreateDefaultBuilder()
                .ConfigureServices((_, services) =>
                {
                    services.UseMicrosoftDependencyResolver();
                    var resolver = Locator.CurrentMutable;
                    resolver.InitializeSplat();
                    resolver.InitializeReactiveUI();

                    services.AddTransient<MainWindow>();
                    services.AddTransient<MainWindowViewModel>();
                    services.AddTransient<AddNewCharacterWindow>();
                    services.AddTransient<HomeViewModel>();
                    services.AddTransient<CharactersViewModel>();
                    services.AddTransient<NoCharactersViewModel>();
                    services.AddTransient<GeneralInfoViewModel>();
                    services.AddTransient<PersonalityViewModel>();
                    services.AddTransient<InterestsViewModel>();
                    services.AddTransient<AppearanceViewModel>();
                    services.AddTransient<ReferenceViewModel>();
                    services.AddSingleton<IMessenger, Messenger>();
                })
                .Build();
            
            Container = host.Services;
            Container.UseMicrosoftDependencyResolver();
            
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow =
                    Locator.Current.GetService<MainWindow>(); // host.Services.GetRequiredService<MainWindow>();
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}