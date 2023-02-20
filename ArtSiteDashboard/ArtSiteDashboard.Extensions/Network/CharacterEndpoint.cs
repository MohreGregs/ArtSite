using ArtSite.Data.Models;

namespace ArtSiteDashboard.Extensions.Network; 

public static partial class Api {
    public static async Task<List<CharacterModel>?> GetCharacters() {
        return await GetRequest<List<CharacterModel>>("character");
    }

    public static async Task<HttpResponseMessage> DeleteCharacter(int id) {
        return await DeleteRequest("character", id);
    }
    
    public static async Task<CharacterModel?> AddCharacter(object character) {
        return await PostRequest<CharacterModel>("character", "add", character);
    }

    public static async Task<HttpRequestMessage?> SetIcon(SetIconModel model) {
        return await PostRequest<HttpRequestMessage>("character", "setIcon", model);
    }
}