using ArtSite.Data.Models;

namespace ArtSiteDashboard.Extensions.Network; 

public static partial class Api {
    public static async Task<List<SpeciesModel>?> GetSpecies() {
        return await GetRequest<List<SpeciesModel>>("species");
    }
    
    public static async Task<SpeciesModel?> GetSpeciesById(int id) {
        return await GetRequest<SpeciesModel>("species", $"getById?id={id}");
    }

    public static async Task<SpeciesModel?> AddSpecies(SpeciesModel species) {
        return await PostRequest<SpeciesModel>("artist", "add", species);
    }
}