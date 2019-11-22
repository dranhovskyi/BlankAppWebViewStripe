using BlankAppWebViewStripe.Services;
using Prism.Navigation;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BlankAppWebViewStripe.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public ICommand GetStripeWebPageCommand { get; set; }

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
        }

        private async Task GetWebPageAndOpenWebView()
        {
            var source = await _paymentService.GetStripeWebPage(AppConstants.WebPageUrl);

            var navParam = new NavigationParameters();
            navParam.Add("source", source);
            await NavigationService.NavigateAsync("WebViewPage", navParam, useModalNavigation: true);
        }
    }
}
