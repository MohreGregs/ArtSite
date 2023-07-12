using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using ArtSite.Data.Models;
using Avalonia.Media.Imaging;

namespace ArtSite.Managment.Network; 

public static partial class Api {
    public static async Task<List<ArtworkModel>?> GetArtworks() {
        return await GetRequest<List<ArtworkModel>>("artwork");
    }
    
    public static async Task<ArtworkModel?> GetArtworkById(int id) {
        return await GetRequest<ArtworkModel>("artwork", $"getById?id={id}");
    }
    
    public static async Task<List<int>?> GetArtworkIdByCharacter(int characterId) {
        return await GetRequest<List<int>>("artwork", $"getArtworkIdByCharacter?characterId={characterId}");
    }

    public static async Task<List<ArtworkModel>?> GetArtworksByCharacterId(int characterId) {
        return await GetRequest<List<ArtworkModel>?>("artwork", $"getByCharacterId?characterId={characterId}");
    }
    
    public static async Task<ArtworkModel?> AddArtwork(object artwork) {
        return await PostRequest<ArtworkModel>("artwork", "add", artwork);
    }
    
    public static async Task<Bitmap> GetFileById(int id) {
        try {
            using (var client = new HttpClient()) {
                var data = await client.GetAsync(new Uri($"{Url}artwork/getFileById?id={id}"));

                return new Bitmap(await data.Content.ReadAsStreamAsync());
            }
        }
        catch(Exception ex) {
            Debug.WriteLine(ex);
            return default;
        }
    }
}