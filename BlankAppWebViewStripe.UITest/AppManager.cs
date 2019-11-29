using System;
using Xamarin.UITest;

namespace BlankAppWebViewStripe.UITest
{
    static class AppManager
    {
        const string ApkPath = @"C:\Users\ndranhovskyi\Documents\BlankAppWebViewStripe\BlankAppWebViewStripe\BlankAppWebViewStripe.Android\bin\Debug\com.companyname.appname.apk";
        const string AppPath = "../../../PrismFilms/PrismFilms.iOS/bin/iPhoneSimulator/Debug/device-builds/iphone10.4-13.0/PrismFilms.iOS.app";
        const string IpaBundleId = "com.company.prismfilms";

        static IApp app;
        public static IApp App
        {
            get
            {
                if (app == null)
                    throw new NullReferenceException("'AppManager.App' not set. Call 'AppManager.StartApp()' before trying to access it.");
                return app;
            }
        }

        static Platform? platform;
        public static Platform Platform
        {
            get
            {
                if (platform == null)
                    throw new NullReferenceException("'AppManager.Platform' not set.");
                return platform.Value;
            }

            set
            {
                platform = value;
            }
        }

        public static void StartApp()
        {
            if (Platform == Platform.Android)
            {
                app = ConfigureApp
                    .Android
                    // Used to run a .apk file:
                    .ApkFile(ApkPath)
                    .StartApp();
            }

            if (Platform == Platform.iOS)
            {
                app = ConfigureApp
                    .iOS
                    // Used to run a .app file on an ios simulator:
                    .AppBundle(AppPath)
                    // Used to run a .ipa file on a physical ios device:
                    //.InstalledApp(ipaBundleId)
                    .StartApp();
            }
        }
    }
}