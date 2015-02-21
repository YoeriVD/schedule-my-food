using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using ScheduleMyFood.IoC;
using ScheduleMyFood.Main;
using Xamarin.Forms;

namespace ScheduleMyFood
{
    public class App : Application
    {
        public App()
        {
            var container = new AppContainer().CreateContainer();
            // The root page of your application
            using (var scope = container.BeginLifetimeScope())
            {
                MainPage = scope.Resolve<MainPage>();
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
