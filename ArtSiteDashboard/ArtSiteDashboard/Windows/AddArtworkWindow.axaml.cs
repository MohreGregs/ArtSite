using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;
using ArtSite.Data.Enums;
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
        ViewModel.Tags = await Api.GetTags() ?? new();
        ViewModel.Artwork.NsfwRating = NSFWRating.None;
        ViewModel.Artwork.GoreRating = GoreRating.None;
    }

    private void Button_OnCancel(object? sender, RoutedEventArgs e) {
        Close();
    }

    private async void Button_OnAdd(object? sender, RoutedEventArgs e) {
        if (ViewModel.Artwork.FileData.Length == 0 || ViewModel.ArtworkArtists.Count == 0 || string.IsNullOrWhiteSpace(ViewModel.Artwork.FileExtension)) {
            return;
        }

        var artistIds = new List<int>();
        foreach (var artworkArtist in ViewModel.ArtworkArtists) {
            artistIds.Add(artworkArtist.Id.Value);
        }
        
        var characterIds = new List<int>();
        foreach (var artworkCharacter in ViewModel.ArtworkCharacters) {
            characterIds.Add(artworkCharacter.Id.Value);
        }

        var artworkToAdd = new AddArtworkModel{
            Description = Encoding.UTF8.GetBytes(ViewModel.ArtworkDescription),
            ArtistIds = artistIds,
            CharacterIds = characterIds,
            NsfwRating = ViewModel.Artwork.NsfwRating,
            GoreRating = ViewModel.Artwork.GoreRating,
            FileData = ViewModel.Artwork.FileData,
            FileExtension = ViewModel.Artwork.FileExtension
        };
        
        var x =await Api.AddArtwork(artworkToAdd);
        
        Close();
    }

    private async void Button_OnOpenFileExplorer(object? sender, RoutedEventArgs e) {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        
        openFileDialog.AllowMultiple = false;
        
        var fileFilter = new FileDialogFilter();
        fileFilter.Name = "Image Files";
        fileFilter.Extensions = new List<string> { "jpg", "png", "gif" };
        openFileDialog.Filters = new List<FileDialogFilter>{fileFilter};
        
        var files = await openFileDialog.ShowAsync(this);
        if (!files.Any()) {
            return;
        }

        ViewModel.Artwork.FileData = File.ReadAllBytes(files.First());
        ViewModel.Artwork.FileExtension = Path.GetExtension(files.First());
    }

    private void InputElement_OnKeyUp_Artist(object? sender, KeyEventArgs e) {
        if (e.Key != Key.Enter) return;

        var x = sender as AutoCompleteBox;

        if (x.SelectedItem == null || ViewModel.ArtworkArtists.Contains(x.SelectedItem)) return;

        var y = ViewModel.ArtworkArtists.ToList();
        y.Add((ArtistModel)x.SelectedItem);
        ViewModel.ArtworkArtists = new ObservableCollection<ArtistModel>(y);
        ViewModel.RaisePropertyChanged(nameof(ViewModel.ArtworkArtists));
        x.Text = "";
    }
    
    private void InputElement_OnKeyUp_Character(object? sender, KeyEventArgs e) {
            if (e.Key != Key.Enter) return;
    
            var x = sender as AutoCompleteBox;
    
            if (x.SelectedItem == null || ViewModel.ArtworkCharacters.Contains(x.SelectedItem)) return;

            var y = ViewModel.ArtworkCharacters.ToList();
            y.Add((CharacterModel)x.SelectedItem);
            ViewModel.ArtworkCharacters = new ObservableCollection<CharacterModel>(y);
            ViewModel.RaisePropertyChanged(nameof(ViewModel.ArtworkCharacters));
            x.Text = "";
    }

    private async void Button_OnAddCharacter(object? sender, RoutedEventArgs e) {
        var characterWindow = new AddNewCharacterWindow();

        await characterWindow.ShowDialog(this);
        ViewModel.Characters = (await Api.GetCharacters()) ?? new();
    }

    private async void Button_OnAddArtist(object? sender, RoutedEventArgs e) {
        var artistWindow = new AddArtistWindow();

        await artistWindow.ShowDialog(this);
        ViewModel.Artists = (await Api.GetArtists()) ?? new();
    }

    private void Button_OnRemoveArtist(object? sender, RoutedEventArgs e) {
        var x = sender as Button;
        var artist = (ArtistModel) x.DataContext;
        
        if (artist == null) return;

        ViewModel.ArtworkArtists.Remove(artist);
    }

    private void Button_OnRemoveCharacter(object? sender, RoutedEventArgs e) {
        var x = sender as Button;
        var character = (CharacterModel) x.DataContext;
        
        if (character == null) return;

        ViewModel.ArtworkCharacters.Remove(character);
    }

    private void InputElement_OnKeyUp_Tag(object? sender, KeyEventArgs e) {
        if (e.Key != Key.Enter) return;

        var x = sender as AutoCompleteBox;

        if (x.SelectedItem == null || ViewModel.ArtworkTags.Contains(x.SelectedItem)) return;

        var y = ViewModel.ArtworkTags.ToList();
        y.Add((TagModel)x.SelectedItem);
        ViewModel.ArtworkTags = new ObservableCollection<TagModel>(y);
        ViewModel.RaisePropertyChanged(nameof(ViewModel.ArtworkTags));
        x.Text = "";
    }

    private async void Button_OnAddTag(object? sender, RoutedEventArgs e) {
        var tagWindow = new AddTagWindow();

        await tagWindow.ShowDialog(this);
        ViewModel.Tags = (await Api.GetTags()) ?? new();
    }

    private void Button_OnRemoveTag(object? sender, RoutedEventArgs e) {
        var x = sender as Button;
        var tag = (TagModel) x.DataContext;
        
        if (tag == null) return;

        ViewModel.ArtworkTags.Remove(tag);
    }
}