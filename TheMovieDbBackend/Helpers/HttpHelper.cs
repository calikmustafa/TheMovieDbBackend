
using System.Text;
using System.Text.Json;

namespace TheMovieDbBackend.API.Helpers
{
    public class HttpHelper
    {
        public static async Task<T> GetDataFromApi<T>(string url) where T : class
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetAsync(url);
                result.EnsureSuccessStatusCode();
                string resultContentString = await result.Content.ReadAsStringAsync();
                T resultContent = System.Text.Json.JsonSerializer.Deserialize<T>(resultContentString);
                return resultContent;


            }

        }
        


    }
}
