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

        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new MainMenu());
            MainPage = new VistaLogin(); 
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
