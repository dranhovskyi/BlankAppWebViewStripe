using Prism.Navigation;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BlankAppWebViewStripe.ViewModels
{
    public class WebViewPageViewModel : ViewModelBase
    {
        public ICommand OnBackButtonClickedCommand { get; set; }

        private string source;
        public string Source
        {
            get { return source; }
            set { SetProperty(ref source, value); }
        }

        public WebViewPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Web view";

            OnBackButtonClickedCommand = new Command(async () => await GoBackAsync());
        }

        private async Task GoBackAsync()
        {
            await NavigationService.GoBackAsync();
        }

        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            Source = parameters.GetValue<string>("source");
        }
    }
}
