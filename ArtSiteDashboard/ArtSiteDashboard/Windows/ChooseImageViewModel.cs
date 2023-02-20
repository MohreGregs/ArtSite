using System.Collections.Generic;
using ArtSite.Data.Models;
using ReactiveUI;

namespace ArtSiteDashboard.Windows; 

public class ChooseImageViewModel : BaseWindowViewModel {
    private List<ArtworkModel>? _artworks;
    private ArtworkModel? _selectedArtwork;
    public int CharacterId;

    public ChooseImageViewModel(){}
    
    public ChooseImageViewModel(int characterId) {
        CharacterId = characterId;
    }

    public List<ArtworkModel>? Artworks {
        get => _artworks;
        set => this.RaiseAndSetIfChanged(ref _artworks, value);
    }
    
    public ArtworkModel? SelectedArtwork {
        get => _selectedArtwork;
        set => this.RaiseAndSetIfChanged(ref _selectedArtwork, value);
    }
}