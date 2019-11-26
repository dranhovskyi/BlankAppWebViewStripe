using Newtonsoft.Json;
using Stripe;

namespace BlankAppWebViewStripe.Models
{
    public class PaymentResult
    {
        [JsonProperty("paymentIntent")]
        public PaymentIntent PaymentIntent { get; set; }
    }
}
