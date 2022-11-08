using ArtSite.Data.Models;
using ReactiveUI;

namespace ArtSiteDashboard.Windows; 

public class AddSongViewModel: BaseWindowViewModel {
    private SongModel _song;

    public AddSongViewModel() {
        Song = new SongModel();
    }
    
    public SongModel Song {
        get => _song;
        set => this.RaiseAndSetIfChanged(ref _song, value);
    }
}