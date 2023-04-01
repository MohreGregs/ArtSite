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
        ViewModel = new ChooseImageViewModel(characterId);
        InitializeComponent();
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
        var ids = await Api.GetArtworkIdByCharacter(ViewModel.CharacterId) ?? new();

        foreach (var id in ids) {
            var file = await Api.GetFileById(id);
            ViewModel.Artworks.Add(new ArtworkFile(id, file));
        }
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
             ViewModel.SelectedArtwork.Id
        );

        await Api.SetIcon(setIconModel);
        Close();
    }

}