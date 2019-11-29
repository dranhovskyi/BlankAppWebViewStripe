using System.Threading.Tasks;

namespace BlankAppWebViewStripe.Services
{
    public interface IRestClient
    {
        Task<TResult> GetAsync<TResult>(string uri);

        Task<TResult> PostAsync<TResult, TBody>(string uri, TBody data);
    }
}