using Prism;
using Prism.Ioc;
using BlankAppWebViewStripe.ViewModels;
using BlankAppWebViewStripe.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BlankAppWebViewStripe.Services;
using DryIoc;
using Prism.DryIoc;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace BlankAppWebViewStripe
{
    public partial class App
    { 
        public static IContainer AppContainer { get; set; }

        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<WebViewPage, WebViewPageViewModel>();

            containerRegistry.RegisterInstance<IPaymentService>(new PaymentService());

            AppContainer = containerRegistry.GetContainer();
        }
    }
}
