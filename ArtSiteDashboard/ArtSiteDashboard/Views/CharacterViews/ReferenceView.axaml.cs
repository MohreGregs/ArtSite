using System.Diagnostics;
using System.Runtime.InteropServices;
using ArtSite.Data.Models;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace ArtSiteDashboard.Views.CharacterViews; 

public partial class ReferenceView : ReactiveControl<ReferenceViewModel> {
    public ReferenceView() {
        InitializeComponent();
    }

    private void InitializeComponent() {
        AvaloniaXamlLoader.Load(this);
    }

    private void ArtistButton_OnTapped(object? sender, RoutedEventArgs e) {
        var textblock = sender as TextBlock;
        var artist = textblock.DataContext as ArtistModel;
        var url = artist.Furaffinity;
        try
        {
            //try to open the url in the default browser
            Process.Start(url);
        }
        catch //If we fail we converter use the native platforms commands
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                url = url.Replace("&", "^&");
                Process.Start(new ProcessStartInfo(url)
                {
                    UseShellExecute = true
                });

                return;
            }
        }
    }
}