using System.Reactive.Disposables;
using ArtSite.Data.Models;
using ArtSiteDashboard.Extensions.Network;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using ReactiveUI;

namespace ArtSiteDashboard.Windows; 

public partial class ChooseImageWindow : ReactiveWindow<ChooseImageViewModel> {
    public ChooseImageWindow(int characterId) {
        InitializeComponent();

        ViewModel = new ChooseImageViewModel(characterId);
#if DEBUG
        this.AttachDevTools();
#endif
    }
    public ChooseImageWindow(){ InitializeComponent();}

    private void InitializeComponent() {
        AvaloniaXamlLoader.Load(this);
        
        this.WhenActivated(Block);
    }
    
    private async void Block(CompositeDisposable obj) {
        ViewModel.Artworks = await Api.GetArtworksByCharacterId(ViewModel.CharacterId) ?? new();
    }

    private void Button_OnCancel(object? sender, RoutedEventArgs e) {
        Close();
    }

    private async void Button_OnChoose(object? sender, RoutedEventArgs e) {
        if (ViewModel?.SelectedArtwork?.Id == default) {
            return;
        }

        var setIconModel = new SetIconModel(
             ViewModel.CharacterId, 
             ViewModel.SelectedArtwork.Id.Value
        );

        await Api.SetIcon(setIconModel);
        Close();
    }

    private void Artwork_SelectionChanged(object? sender, SelectionChangedEventArgs e) {
        var x = sender as ListBox;
        ViewModel.SelectedArtwork = x.SelectedItem as ArtworkModel;
    }
}