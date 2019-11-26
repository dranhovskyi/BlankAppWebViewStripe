using Prism.Navigation;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BlankAppWebViewStripe.ViewModels
{
    public class WebViewPageViewModel : ViewModelBase
    {
        public ICommand OnBackButtonClickedCommand { get; set; }
        public ICommand GetResultCommand { get; set; }

        private string source;
        public string Source
        {
            get { return source; }
            set { SetProperty(ref source, value); }
        }

        private INavigationService _navigationService;

        public WebViewPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Web view";

            this._navigationService = navigationService;

            OnBackButtonClickedCommand = new Command(async () => await GoBackAsync());
            GetResultCommand = new Command(async (obj) => await ProcessResult(obj));
        }

        private async Task ProcessResult(object result)
        {            
            var navParam = new NavigationParameters();
            navParam.Add("result", result);
            await this._navigationService.GoBackAsync(navParam);
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
