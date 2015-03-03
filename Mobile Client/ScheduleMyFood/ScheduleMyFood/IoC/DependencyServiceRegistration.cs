using Autofac;
using ScheduleMyFood.Technical.DependencyServices;
using Xamarin.Forms;

namespace ScheduleMyFood.IoC
{
    class DependencyServiceRegistration : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => DependencyService.Get<ILocalStorageService>());
            base.Load(builder);
        }
    }
}
