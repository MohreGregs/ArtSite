using ArtSite.Data.Models;

namespace ArtSiteDashboard.Extensions.Network; 

public static partial class Api {
    public static async Task<List<BaseNameModel>?> GetHobbies() {
        return await GetRequest<List<BaseNameModel>>("hobby");
    }
    
    public static async Task<BaseNameModel?> GetHobbyById(int id) {
        return await GetRequest<BaseNameModel>("hobby", $"getById?id={id}");
    }

    public static async Task<BaseNameModel?> AddHobby(object hobby) {
        return await PostRequest<BaseNameModel>("hobby", "add", hobby);
    }
}