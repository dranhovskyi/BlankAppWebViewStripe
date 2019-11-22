using BlankAppWebViewStripe.Interfaces;
using BlankAppWebViewStripe.UWP.Dependencies;
using Xamarin.Forms;

[assembly: Dependency(typeof(BaseUrl))]
namespace BlankAppWebViewStripe.UWP.Dependencies
{
    public class BaseUrl : IBaseUrl
    {
        public string Get()
        {
            return "ms-appx-web:///";
        }
    }
}
