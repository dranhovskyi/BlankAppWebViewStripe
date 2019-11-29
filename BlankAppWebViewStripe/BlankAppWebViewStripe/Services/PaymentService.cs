using System;
using System.Threading.Tasks;
using BlankAppWebViewStripe.Models;
using Stripe;

namespace BlankAppWebViewStripe.Services
{
    public class PaymentService : IPaymentService
    {
        public async Task<string> GetTransactionId()
        {
            RestClient restClient = new RestClient();
            return await restClient.GetAsync<string>(AppConstants.GetTransactionIdUrl);
        }

        public string GetStripeWebPage(string transactionId)
        {
            return  String.Format(AppConstants.WebPageUrl, transactionId);
        }

        public async Task<StripeResponse> SendPaymentResult(PaymentResult paymentResult)
        {
            RestClient restClient = new RestClient();
            return await restClient.PostAsync<StripeResponse, PaymentResult>(AppConstants.SendPaymentResultUrl, paymentResult);
        }
    }
}
