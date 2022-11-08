using ArtSiteDashboard.Extensions.Network;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace ArtSiteDashboard.Windows; 

public partial class AddSongWindow : ReactiveWindow<AddSongViewModel> {
    public AddSongWindow() {
        InitializeComponent();

        ViewModel = new AddSongViewModel();
        
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
        if (string.IsNullOrWhiteSpace(ViewModel.Song.Name) || string.IsNullOrWhiteSpace(ViewModel.Song.Interpret) || string.IsNullOrWhiteSpace(ViewModel.Song.Link)) {
            return;
        }
        
        var songToAdd = new {
            Name = ViewModel.Song.Name,
            Interpret = ViewModel.Song.Interpret,
            Link = ViewModel.Song.Link
        };
        
        var x = await Api.AddSong(songToAdd);
        
        Close();
    }
}