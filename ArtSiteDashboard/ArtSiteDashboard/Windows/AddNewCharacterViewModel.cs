using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ArtSite.Data.Enums;
using ArtSite.Data.Models;
using ReactiveUI;

namespace ArtSiteDashboard.Views; 

public class AddNewCharacterViewModel : BaseWindowViewModel {
    public int? CharacterId; 
    
    private AddCharacterModel _character;
    private List<SpeciesModel> _species = new();
    private SpeciesModel _characterSpecies;
    private List<TagModel> _tags = new();
    private ObservableCollection<TagModel> _characterTags = new();
    private List<ArtistModel> _artists = new();
    private ArtistModel _characterDesigner;

    public AddNewCharacterViewModel(int? characterId) {
        CharacterId = characterId;
    }

    public AddCharacterModel Character {
        get => _character;
        set => this.RaiseAndSetIfChanged(ref _character, value);
    }

    public List<SpeciesModel> Species {
        get => _species;
        set => this.RaiseAndSetIfChanged(ref _species, value);
    }

    public SpeciesModel CharacterSpecies {
        get => _characterSpecies;
        set => this.RaiseAndSetIfChanged(ref _characterSpecies, value);
    }

    public List<TagModel> Tags {
        get => _tags;
        set => this.RaiseAndSetIfChanged(ref _tags, value);
    }

    public ObservableCollection<TagModel> CharacterTags {
        get => _characterTags;
        set => this.RaiseAndSetIfChanged(ref _characterTags, value);
    }

    public List<ArtistModel> Artists {
        get => _artists;
        set => this.RaiseAndSetIfChanged(ref _artists, value);
    }

    public ArtistModel CharacterDesigner {
        get => _characterDesigner;
        set => this.RaiseAndSetIfChanged(ref _characterDesigner, value);
    }

    public IEnumerable<Gender> GenderValues => Enum.GetValues<Gender>();

    public IEnumerable<Sexuality> SexualityValues => Enum.GetValues<Sexuality>();
    
}