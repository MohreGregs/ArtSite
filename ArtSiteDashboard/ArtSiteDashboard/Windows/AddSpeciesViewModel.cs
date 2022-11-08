using ArtSite.Data.Models;
using ReactiveUI;

namespace ArtSiteDashboard.Windows; 

public class AddSpeciesViewModel: BaseWindowViewModel {
    private SpeciesModel _species;

    public SpeciesModel Species {
        get => _species;
        set => this.RaiseAndSetIfChanged(ref _species, value);
    }

    public AddSpeciesViewModel() {
        Species = new SpeciesModel();
    }
}