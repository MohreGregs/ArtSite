using ArtSite.Data.Models;

namespace ArtSiteDashboard.Extensions.Network; 

public static partial class Api {
    public static async Task<List<CharacterModel>?> GetCharacters() {
        return await GetRequest<List<CharacterModel>>("character");
    }

    public static async Task<CharacterModel?> GetCharacterById(int id) {
        return await GetRequest<CharacterModel?>("character", $"getById?id={id}");
    }

    public static async Task<HttpResponseMessage> DeleteCharacter(int id) {
        return await DeleteRequest("character", id);
    }
    
    public static async Task<CharacterModel?> AddCharacter(object character) {
        return await PostRequest<CharacterModel>("character", "add", character);
    }

    public static async Task<CharacterModel?> EditCharacter(object character) {
        return await PutRequest<CharacterModel>("character", "editSimple", character);
    }
    
    public static async Task<CharacterModel?> EditExtraCharacterInfo(object character) {
        return await PutRequest<CharacterModel>("character", "editExtraInfo", character);
    }

    public static async Task<HttpRequestMessage?> SetIcon(SetIconModel model) {
        return await PostRequest<HttpRequestMessage>("character", "setIcon", model);
    }
}