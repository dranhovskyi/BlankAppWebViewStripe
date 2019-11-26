using BlankAppWebViewStripe.Models;
using BlankAppWebViewStripe.Services;
using Newtonsoft.Json;
using Prism.Navigation;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BlankAppWebViewStripe.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public ICommand GetStripeWebPageCommand { get; set; }

        private PaymentResult _paymentResult;
        public PaymentResult PaymentResult
        {
            get { return _paymentResult; }
            set { SetProperty(ref _paymentResult, value); }
        }

        readonly private IPaymentService _paymentService;

        public MainPageViewModel(INavigationService navigationService, IPaymentService paymentService)
            : base(navigationService)
        {
            this._paymentService = paymentService;

            Title = "Main Page";
            GetStripeWebPageCommand = new Command(async () => await GetWebPageAndOpenWebView());
        }

        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            var result = parameters["result"];
            if (result is string json)
            {
                var desirialized = JsonConvert.DeserializeObject<PaymentResult>(json);
                if (desirialized is PaymentResult paymentResult)
                {
                    PaymentResult = paymentResult;
                }
            }
        }

        private async Task GetWebPageAndOpenWebView()
        {
            var source = await _paymentService.GetStripeWebPage(AppConstants.WebPageUrl);

            var navParam = new NavigationParameters();
            navParam.Add("source", source);
            await NavigationService.NavigateAsync("WebViewPage", navParam, true);
        }
    }
}
