using System.Windows.Input;
using Xamarin.Forms;

namespace BlankAppWebViewStripe.Controls
{
    public class HybridWebView : View
    {
        public static readonly BindableProperty CommandProperty = BindableProperty.Create
            (nameof(Command),
            typeof(ICommand),
            typeof(HybridWebView));

        public static readonly BindableProperty UriProperty = BindableProperty.Create
            (nameof(Uri),
            typeof(string),
            typeof(HybridWebView),
            default(string),
            BindingMode.TwoWay);

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public string Uri
        {
            get { return (string)GetValue(UriProperty); }
            set { SetValue(UriProperty, value); }
        }

        public void Cleanup()
        {
            Command = null;
        }

        public void InvokeCommand(object data)
        {
            if (Command == null || data == null)
            {
                return;
            }
            Command.Execute(data);
        }
    }
}
