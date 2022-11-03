
using ArtSite.Data.Models;

namespace ArtSiteDashboard.Extensions.Network; 

public static partial class Api {
    public static async Task<List<ColorModel>?> GetColors() {
        return await GetRequest<List<ColorModel>>("color");
    }
    
    public static async Task<ColorModel?> GetColorById(int id) {
        return await GetRequest<ColorModel>("color", $"getById?id={id}");
    }
    
    public static async Task<ColorModel?> AddColor(object color) {
        return await PostRequest<ColorModel>("color", "add", color);
    }

    public static async Task<HttpResponseMessage> DeleteColor(int id) {
        return await DeleteRequest("color", id);
    }
}