using System.Net.Http;
using System.Threading.Tasks;

namespace Weather.Data.Interfaces
{
    public interface IHttpClient
    {
        Task<string> GetAsync(string url);

        Task PostAsync(string url, HttpContent content);
    }
}
