using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFirebaseApp.Views.Student;

namespace XamarinFirebaseApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new StudentListPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
