using ArtSite.Data.Models;

namespace ArtSiteDashboard.Extensions.Network; 

public static partial class Api {
    public static async Task<List<ArtworkModel>?> GetArtworks() {
        return await GetRequest<List<ArtworkModel>>("artwork");
    }
    
    public static async Task<ArtworkModel?> GetArtworkById(int id) {
        return await GetRequest<ArtworkModel>("artwork", $"getById?id={id}");
    }

    public static async Task<List<ArtworkModel>?> GetArtworksByCharacterId(int characterId) {
        return await GetRequest<List<ArtworkModel>?>("artwork", $"getByCharacterId?characterId={characterId}");
    }
    
    public static async Task<ArtworkModel?> AddArtwork(object artwork) {
        return await PostRequest<ArtworkModel>("artwork", "add", artwork);
    }
}