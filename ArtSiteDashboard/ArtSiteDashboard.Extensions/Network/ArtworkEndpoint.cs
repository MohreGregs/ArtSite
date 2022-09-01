using ArtSite.Data.Models;

namespace ArtSiteDashboard.Extensions.Network; 

public static partial class Api {
    public static async Task<List<ArtworkModel>?> GetArtworks() {
        return await GetRequest<List<ArtworkModel>>("artwork");
    }
    
    public static async Task<ArtworkModel?> GetArtworkById(int id) {
        return await GetRequest<ArtworkModel>("artwork", $"getById?id={id}");
    }
}