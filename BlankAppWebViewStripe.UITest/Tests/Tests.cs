using BlankAppWebViewStripe.UITest.Pages;
using NUnit.Framework;
using Xamarin.UITest;

namespace BlankAppWebViewStripe.UITest.Tests
{
    public class Tests : BaseTestFixture
    {
        public Tests(Platform platform)
            : base(platform)
        {
        }

        [Test]
        public void OpenMainPageAndClickButton()
        {
            new MainPage()
                .ClickButton();

            app.Repl();
        }
    }
}
