using System.Collections.ObjectModel;
using ArtSite.Data.Models;
using ReactiveUI;

namespace ArtSiteDashboard.Views; 

public class AddNewCharacterViewModel : BaseWindowViewModel {
    private AddCharacterModel _character;
    private Collection<SpeciesModel> _species;

    public AddNewCharacterViewModel() {
        Character = new AddCharacterModel();
    }

    public AddCharacterModel Character {
        get => _character;
        set => this.RaiseAndSetIfChanged(ref _character, value);
    }

    public Collection<SpeciesModel> Species {
        get => _species;
        set => this.RaiseAndSetIfChanged(ref _species, value);
    }
}