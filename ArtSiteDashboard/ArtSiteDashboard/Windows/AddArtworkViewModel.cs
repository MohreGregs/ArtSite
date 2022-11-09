using System.Collections.Generic;
using System.Collections.ObjectModel;
using ArtSite.Data.Models;
using ArtSite.Data.Models.ReactiveModels;
using ReactiveUI;

namespace ArtSiteDashboard.Windows;

public class AddArtworkViewModel : BaseWindowViewModel {
    private List<ArtistModel> _artists = new();
    private ReactiveAddArtworkModel _artwork;
    private ObservableCollection<ArtistModel> _artworkArtists = new();
    private List<CharacterModel> _characters;
    private ObservableCollection<CharacterModel> _artworkCharacters = new();
    private string _artworkDescription;

    public AddArtworkViewModel() {
        Artwork = new ReactiveAddArtworkModel();
    }

    public string ArtworkDescription {
        get => _artworkDescription;
        set => this.RaiseAndSetIfChanged(ref _artworkDescription, value);
    }

    public ReactiveAddArtworkModel Artwork {
        get => _artwork;
        set => this.RaiseAndSetIfChanged(ref _artwork, value);
    }

    public ObservableCollection<ArtistModel> ArtworkArtists {
        get => _artworkArtists;
        set => this.RaiseAndSetIfChanged(ref _artworkArtists, value);
    }

    public List<ArtistModel> Artists {
        get => _artists;
        set => this.RaiseAndSetIfChanged(ref _artists, value);
    }

    public List<CharacterModel> Characters {
        get => _characters;
        set => _characters = value;
    }

    public ObservableCollection<CharacterModel> ArtworkCharacters {
        get => _artworkCharacters;
        set => this.RaiseAndSetIfChanged(ref _artworkCharacters, value);
    }
}