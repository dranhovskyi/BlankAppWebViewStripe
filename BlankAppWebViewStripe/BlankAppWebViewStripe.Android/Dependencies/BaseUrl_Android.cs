using BlankAppWebViewStripe.Droid.Dependencies;
using BlankAppWebViewStripe.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(BaseUrl_Android))]
namespace BlankAppWebViewStripe.Droid.Dependencies
{
    public class BaseUrl_Android : IBaseUrl
    {
        public string Get()
        {
            return "file:///android_asset/";
        }
    }
}