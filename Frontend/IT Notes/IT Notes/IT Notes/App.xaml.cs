using IT_Notes.Views.Pages;
using MailXamarin.Utils;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IT_Notes
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;

            MainPage = new NavigationPage(new pStartPage());
        }

        private async void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            await MainPage.ShowInfoAlert(e.Exception.Message);
        }

        private async void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            await MainPage.ShowInfoAlert(e.ExceptionObject.ToString());
        }

        protected override async void OnStart()
        {
            if (!await ServerRequestFacade.CheckConnection())
            {
                await MainPage.ShowInfoAlert("Не удалось подключиться к серверу");
                Process.GetCurrentProcess().Kill();
            }
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}