using oldSolutions.Vista;
using oldSolutions.Vista.DrawMenu;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace oldSolutions
{
    public partial class App : Application
    {
        public static string FilePath;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainMenu());
        }
        public App(String filePath)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainMenu());
            //MainPage = new VistaLogin();
            FilePath = filePath;
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
