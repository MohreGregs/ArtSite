using System.IO;
using System.Linq;
using System.Net;
using ArtSite.Data.Models;
using ArtSiteDashboard.Extensions.Network;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using ReactiveUI;

namespace ArtSiteDashboard.Windows; 

public partial class AddArtworkWindow : ReactiveWindow<AddArtworkViewModel> {
    public AddArtworkWindow() {
        InitializeComponent();

        ViewModel = new AddArtworkViewModel();
        
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
        if (ViewModel.Artwork.FileData.Length == 0 || ViewModel.Artwork.Artists.Count == 0 || string.IsNullOrWhiteSpace(ViewModel.Artwork.FileExtension)) {
            return;
        }
        
        var artworkToAdd = new {
            Description = ViewModel.Artwork.Description,
            Artists = ViewModel.Artwork.Artists,
            Rating = ViewModel.Artwork.Rating,
            FileData = ViewModel.Artwork.FileData,
            FileExtension = ViewModel.Artwork.FileExtension
        };
        
        var x =await Api.AddArtwork(artworkToAdd);
        
        Close();
    }

    private async void Button_OnOpenFileExplorer(object? sender, RoutedEventArgs e) {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        var files = await openFileDialog.ShowAsync(this);
        if (!files.Any()) {
            return;
        }

        ViewModel.Artwork.FileData = File.ReadAllBytes(files.First());
    }

    private void AutoCompleteBox_OnSelectionChanged(object? sender, SelectionChangedEventArgs e) {
        throw new System.NotImplementedException();
    }
}