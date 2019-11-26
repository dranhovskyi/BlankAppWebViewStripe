using BlankAppWebViewStripe.Controls;
using BlankAppWebViewStripe.UWP.Renderers;
using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using Windows.UI.Xaml.Controls;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(HybridWebView), typeof(HybridWebViewRenderer))]
namespace BlankAppWebViewStripe.UWP.Renderers
{
    public class HybridWebViewRenderer : ViewRenderer<HybridWebView, Windows.UI.Xaml.Controls.WebView>
    {
        const string JavaScriptFunction = "function invokeCSharpAction(data){ window.external.notify(data); }";

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Element == null || Control == null)
            {
                return;
            }

            if (e.PropertyName == HybridWebView.UriProperty.PropertyName)
            {
                //Control.Source = new Uri(string.Format("ms-appx-web:///{0}", Element.Uri));
                //Control.Source = new Uri(Element.Uri);
                try
                {
                    WebClient myClient = new WebClient();
                    Stream response = myClient.OpenRead(Element.Uri);
                    StreamReader reader = new StreamReader(response);
                    string source = reader.ReadToEnd();
                    Control.NavigateToString(source);
                }
                catch (Exception ex) { }
            }
        }

		protected override void OnElementChanged(ElementChangedEventArgs<HybridWebView> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                if (Control != null)
                {
                    Control.NavigationCompleted -= OnWebViewNavigationCompleted;
                    Control.ScriptNotify -= OnWebViewScriptNotify;
                }
            }

            if (e.NewElement != null)
            {
                if (Control == null)
                {
                    SetNativeControl(new Windows.UI.Xaml.Controls.WebView());
                }
                Control.NavigationCompleted += OnWebViewNavigationCompleted;
                Control.ScriptNotify += OnWebViewScriptNotify;
            }
        }

        async void OnWebViewNavigationCompleted(WebView sender, WebViewNavigationCompletedEventArgs args)
        {
            if (args.IsSuccess)
            {
                // Inject JS script
                await Control.InvokeScriptAsync("eval", new[] { JavaScriptFunction });
            }
        }

        void OnWebViewScriptNotify(object sender, NotifyEventArgs e)
        {
            Element.InvokeCommand(e.Value);
        }
    }
}
