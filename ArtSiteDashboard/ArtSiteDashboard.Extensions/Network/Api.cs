using System.Diagnostics;
using System.Text;
using Avalonia.Media.Imaging;
using Newtonsoft.Json;

namespace ArtSiteDashboard.Extensions.Network; 

public static partial class Api {
    public static async Task<T?> GetRequest<T>(string controller, string action = "") {
        try {
            using (var client = new HttpClient()) {
                var data = await client.GetByteArrayAsync(new Uri($"{Url}{controller}/{action}"));

                return JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(data));
            }
        }
        catch(Exception ex) {
            Debug.WriteLine(ex);
            return default;
        }
    }

    public static async Task<T?> PostRequest<T>(string controller, string action, object? data) {
        try {
            using (var client = new HttpClient()) {
                var url = $"{Url}{controller}/{action}";
                
                var req = new HttpRequestMessage(HttpMethod.Post, url);
                var jsonstring = JsonConvert.SerializeObject(data);
                req.Content = new StringContent(jsonstring, Encoding.UTF8, "application/json");

                var result = await client.SendAsync(req);
                
                return JsonConvert.DeserializeObject<T>(await result.Content.ReadAsStringAsync());
            }
        }
        catch(Exception ex) {
            Debug.WriteLine(ex);
            return default;
        }
    }
    
    public static async Task<T?> PutRequest<T>(string controller, string action, object? data) {
        try {
            using (var client = new HttpClient()) {
                var url = $"{Url}{controller}/{action}";
                
                var req = new HttpRequestMessage(HttpMethod.Put, url);
                var jsonstring = JsonConvert.SerializeObject(data);
                req.Content = new StringContent(jsonstring, Encoding.UTF8, "application/json");

                var result = await client.SendAsync(req);
                
                return JsonConvert.DeserializeObject<T>(await result.Content.ReadAsStringAsync());
            }
        }
        catch(Exception ex) {
            Debug.WriteLine(ex);
            return default;
        }
    }

    public static async Task<HttpResponseMessage> DeleteRequest(string controller, int id) {
        try {
            using (var client = new HttpClient()) {
                var url = $"{Url}{controller}/delete?id={id}";

                var req = new HttpRequestMessage(HttpMethod.Delete, url);

                return await client.SendAsync(req);
            }
        }
        catch(Exception ex) {
            Debug.WriteLine(ex);
            return default;
        }
    }

    public static string Url => "http://localhost:5000/";
}