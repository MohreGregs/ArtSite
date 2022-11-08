using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reactive.Disposables;
using ArtSite.Data.Models;
using ArtSiteDashboard.Extensions.Network;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
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

        this.WhenActivated(Block);
    }

    private async void Block(CompositeDisposable obj) {
        ViewModel.Artists = (await Api.GetArtists()) ?? new();
        ViewModel.Characters = (await Api.GetCharacters()) ?? new();
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

    private void InputElement_OnKeyUp_Artist(object? sender, KeyEventArgs e) {
        if (e.Key != Key.Enter) return;

        var x = sender as AutoCompleteBox;

        if (x.SelectedItem == null) return;

        var y = ViewModel.ArtworkArtists.ToList();
        y.Add((ArtistModel)x.SelectedItem);
        ViewModel.ArtworkArtists = new ObservableCollection<ArtistModel>(y);
        ViewModel.RaisePropertyChanged(nameof(ViewModel.ArtworkArtists));
    }
    
    private void InputElement_OnKeyUp_Character(object? sender, KeyEventArgs e) {
            if (e.Key != Key.Enter) return;
    
            var x = sender as AutoCompleteBox;
    
            if (x.SelectedItem == null) return;
    
            var y = ViewModel.ArtworkCharacters.ToList();
            y.Add((CharacterModel)x.SelectedItem);
            ViewModel.ArtworkCharacters = new ObservableCollection<CharacterModel>(y);
            ViewModel.RaisePropertyChanged(nameof(ViewModel.ArtworkCharacters));
        }
}