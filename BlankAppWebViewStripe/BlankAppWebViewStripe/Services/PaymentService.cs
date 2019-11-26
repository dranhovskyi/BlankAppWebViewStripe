using System.Threading.Tasks;

namespace BlankAppWebViewStripe.Services
{
    public class PaymentService : IPaymentService
    {
        public async Task<string> GetStripeWebPage(string uri)
        {
            //RestClient<string> restClient = new RestClient<string>();
            //var webPage = await restClient.GetAsync(uri);
            //return webPage;
            return "http://localhost:53876/MakePayment";
        }
    }
}
