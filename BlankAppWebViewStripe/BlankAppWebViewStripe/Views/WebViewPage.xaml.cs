using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlankAppWebViewStripe.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WebViewPage : ContentPage
    {
        public WebViewPage()
        {
            InitializeComponent();

            hybridWebView.RegisterAction(data => App.Current.MainPage.DisplayAlert("Alert", "Hello " + data, "OK"));
        }
    }
}