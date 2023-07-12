using System.Collections.Generic;
using System.Threading.Tasks;
using ArtSite.Data.Models;

namespace ArtSite.Managment.Network; 

public static partial class Api {
    public static async Task<List<SpeciesModel>?> GetSpecies() {
        return await GetRequest<List<SpeciesModel>>("species");
    }
    
    public static async Task<SpeciesModel?> GetSpeciesById(int id) {
        return await GetRequest<SpeciesModel>("species", $"getById?id={id}");
    }

    public static async Task<SpeciesModel?> AddSpecies(object species) {
        return await PostRequest<SpeciesModel>("species", "add", species);
    }
}