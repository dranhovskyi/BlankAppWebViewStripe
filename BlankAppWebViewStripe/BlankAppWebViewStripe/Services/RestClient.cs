using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlankAppWebViewStripe.Services
{
    public class RestClient<T>
    {
        public async Task<T> GetAsync(string uri)
        {
            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync(uri);
                return JsonConvert.DeserializeObject<T>(json);
            }
        }
    }
}
