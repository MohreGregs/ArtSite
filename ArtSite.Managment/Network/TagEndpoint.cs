using System.Collections.Generic;
using System.Threading.Tasks;
using ArtSite.Data.Models;

namespace ArtSite.Managment.Network; 

public static partial class Api {
    public static async Task<List<TagModel>?> GetTags() {
        return await GetRequest<List<TagModel>>("tag");
    }
    
    public static async Task<TagModel?> GetTagById(int id) {
        return await GetRequest<TagModel>("tag", $"getById?id={id}");
    }

    public static async Task<TagModel?> AddTag(object tag) {
        return await PostRequest<TagModel>("tag", "add", tag);
    }
}