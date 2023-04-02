using System;
using System.Collections.Generic;
using ArtSite.Data.Enums;
using ArtSite.Data.Models;
using ArtSiteDashboard.Views;
using ReactiveUI;

namespace ArtSiteDashboard.Windows; 

public class AddArtistViewModel : BaseWindowViewModel {
    private ArtistModel _artist;

    public AddArtistViewModel() {
        Artist = new ArtistModel();
    }

    public ArtistModel Artist {
        get => _artist;
        set => this.RaiseAndSetIfChanged(ref _artist, value);
    }
}