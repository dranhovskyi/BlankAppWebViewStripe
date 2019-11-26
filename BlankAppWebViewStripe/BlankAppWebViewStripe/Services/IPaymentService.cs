using System.Threading.Tasks;

namespace BlankAppWebViewStripe.Services
{
    public interface IPaymentService
    {
        Task<string> GetStripeWebPage(string uri);
    }
}
