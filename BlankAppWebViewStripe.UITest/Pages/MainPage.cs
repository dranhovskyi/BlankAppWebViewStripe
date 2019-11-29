// Aliases Func<AppQuery, AppQuery> with Query

using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace BlankAppWebViewStripe.UITest.Pages
{
    public class MainPage : BasePage
    {
        readonly Query button;

        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked("content"),
            iOS = x => x.Marked("mainPage")
        };

        public MainPage()
        {
            button = x => x.Marked("button");
        }

        public void ClickButton()
        {
            app.WaitForElement(button);
            app.Tap(button);

            app.WaitForElement(x => x.XPath("//iframe[@name=\"__privateStripeFrame5\"]"));
            app.EnterText(x => x.Switch().XPath("//iframe[@name=\"__privateStripeFrame5\"]"), "4242 4242 4242 4242");
            app.Tap(x => x.WebView().XPath("//button[@name=\"submit\"]"));
        }
    }
}
