using ArtSite.Data.Models;
using ArtSiteDashboard.Extensions.Network;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace ArtSiteDashboard.Windows; 

public partial class AddArtistWindow : ReactiveWindow<AddArtistViewModel> {
    public AddArtistWindow() {
        InitializeComponent();
        
        ViewModel = new AddArtistViewModel();
        
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
        if (string.IsNullOrWhiteSpace(ViewModel.Artist.Name)) {
            return;
        }
        
        var artistToAdd = new ArtistModel {
            Name = ViewModel.Artist.Name,
            Website = ViewModel.Artist.Website,
            Furaffinity = ViewModel.Artist.Furaffinity,
            Artfight = ViewModel.Artist.Artfight,
            ToyHouse = ViewModel.Artist.ToyHouse,
            Twitter = ViewModel.Artist.Twitter
        };
        
        var x =await Api.AddArtist(artistToAdd);
        
        Close();
    }
}