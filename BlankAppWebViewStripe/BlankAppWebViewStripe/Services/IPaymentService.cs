using System.Threading.Tasks;
using BlankAppWebViewStripe.Models;
using Stripe;

namespace BlankAppWebViewStripe.Services
{
    public interface IPaymentService
    {

        Task<string> GetTransactionId();

        string GetStripeWebPage(string transactionId);

        Task<StripeResponse> SendPaymentResult(PaymentResult paymentResult);
    }
}
