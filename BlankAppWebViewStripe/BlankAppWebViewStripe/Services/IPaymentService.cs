using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlankAppWebViewStripe.Services
{
    public interface IPaymentService
    {
        Task<string> GetStripeWebPage(string uri);
    }
}
