using ArtSite.Data.Models;

namespace ArtSiteDashboard.Extensions.Network; 

public static partial class Api {
    public static async Task<List<SongModel>?> GetSongs() {
        return await GetRequest<List<SongModel>>("song");
    }
    
    public static async Task<SongModel?> GetSongById(int id) {
        return await GetRequest<SongModel>("song", $"getById?id={id}");
    }

    public static async Task<SongModel?> AddSong(object song) {
        return await PostRequest<SongModel>("song", "add", song);
    }
}