using ArtSiteDashboard.Extensions.Network;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace ArtSiteDashboard.Windows; 

public partial class AddHobbyWindow : ReactiveWindow<AddHobbyViewModel> {
    public AddHobbyWindow() {
        InitializeComponent();

        ViewModel = new AddHobbyViewModel();
        
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
        if (string.IsNullOrWhiteSpace(ViewModel.HobbyName)) {
            return;
        }
        
        var tagToAdd = new {
            Name = ViewModel.HobbyName
        };
        
        var x = await Api.AddHobby(tagToAdd);
        
        Close();
    }
}