using ArtSite.Data.Models;
using ReactiveUI;

namespace ArtSiteDashboard.Windows; 

public class AddArtworkViewModel : BaseWindowViewModel {
    private AddArtworkModel _artwork;

    public AddArtworkModel Artwork {
        get => _artwork;
        set => this.RaiseAndSetIfChanged(ref _artwork, value);
    }

    public AddArtworkViewModel() {
        Artwork = new AddArtworkModel();
    }
}