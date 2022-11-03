using ArtSite.Data.Models;
using ArtSiteDashboard.Extensions.Network;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace ArtSiteDashboard.Windows; 

public partial class AddColorWindow : ReactiveWindow<AddColorViewModel> {
    public AddColorWindow() {
        InitializeComponent();

        ViewModel = new AddColorViewModel();
        
#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent() {
        AvaloniaXamlLoader.Load(this);
    }
    
    private void Button_OnCancel(object? sender, RoutedEventArgs e) {
        Close();
    }

    private async void Button_OnAdd(object? sender, RoutedEventArgs e) {
        if (string.IsNullOrWhiteSpace(ViewModel.Color.Name) || string.IsNullOrWhiteSpace(ViewModel.Color.ColorCode)) {
            return;
        }
        
        var colorToAdd = new {
            Name = ViewModel.Color.Name,
            ColorCode = ViewModel.Color.ColorCode,
        };
        
        var x =await Api.AddColor(colorToAdd);
        
        Close();
    }
}