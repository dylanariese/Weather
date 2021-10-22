using System.Net.Http;
using System.Threading.Tasks;
using Weather.Data.Interfaces;

namespace Weather.Infrastructure
{
    public class HttpClientWrapper : IHttpClient
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<string> GetAsync(string url)
        {
            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        public async Task PostAsync(string url, HttpContent content)
        {
            var response = await client.PostAsync(url, content);

            response.EnsureSuccessStatusCode();
        }
    }
}