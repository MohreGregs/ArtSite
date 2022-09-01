using ArtSite.Data.Models;

namespace ArtSiteDashboard.Extensions.Network; 

public static partial class Api {
    public static async Task<List<ArtistModel>?> GetArtists() {
        return await GetRequest<List<ArtistModel>>("artist");
    }
    
    public static async Task<ArtistModel?> GetArtisById(int id) {
        return await GetRequest<ArtistModel>("artist", $"getById?id={id}");
    }

    public static async Task<ArtistModel?> AddArtist(ArtistModel artist) {
        return await PostRequest<ArtistModel>("artist", "add", artist);
    }
}