using Autofac;
using ScheduleMyFood.Authentication;
using ScheduleMyFood.IoC;
using Xamarin.Forms;

namespace ScheduleMyFood
{
    public class App : Application
    {
        internal static class Constants
        {
            internal const string BaseUrl = "http://schedule-my-food.azurewebsites.net";
            internal const string ApplicationJson = "application/json";
        }
        private readonly IContainer _container;

        public App()
        {
            _container = new AppContainer().CreateContainer();
            // The root page of your application
            MainPage = new NavigationPage(GetPage<LoginPage>());
        }
        internal Page GetPage<T>() where T : Page
        {
            using (var scope = _container.BeginLifetimeScope())
            {
                return scope.Resolve<T>();
            }
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
