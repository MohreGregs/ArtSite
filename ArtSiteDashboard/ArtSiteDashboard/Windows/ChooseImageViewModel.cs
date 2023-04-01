using System.Collections.Generic;
using System.Collections.ObjectModel;
using ArtSite.Data.Models;
using Avalonia.Media.Imaging;
using ReactiveUI;

namespace ArtSiteDashboard.Windows; 

public class ChooseImageViewModel : BaseWindowViewModel {
    private ObservableCollection<ArtworkFile>? _artworks = new();
    private ArtworkFile? _selectedArtwork;
    public int CharacterId;

    public ChooseImageViewModel(){}
    
    public ChooseImageViewModel(int characterId) {
        CharacterId = characterId;
    }

    public ObservableCollection<ArtworkFile>? Artworks {
        get => _artworks;
        set => this.RaiseAndSetIfChanged(ref _artworks, value);
    }
    
    public ArtworkFile? SelectedArtwork {
        get => _selectedArtwork;
        set => this.RaiseAndSetIfChanged(ref _selectedArtwork, value);
    }
}