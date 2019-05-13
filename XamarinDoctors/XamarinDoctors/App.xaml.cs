using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinDoctors.Configuration;
using XamarinDoctors.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XamarinDoctors
{
    public partial class App : Application
    {
        private static IoCConfiguration _Locator;
        public static IoCConfiguration Locator
        {
            get
            {
                return _Locator = _Locator ?? new IoCConfiguration();
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new Doctors();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
