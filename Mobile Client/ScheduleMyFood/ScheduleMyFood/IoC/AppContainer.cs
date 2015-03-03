using System.Reflection;
using Autofac;

namespace ScheduleMyFood.IoC
{
    public class AppContainer
    {
        public IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();
            // Registers all modules
            builder.RegisterAssemblyModules(this.GetType().GetTypeInfo().Assembly);
            //builder.RegisterInstance(Application.Current).As<App>().ExternallyOwned();
            return builder.Build();
        }
    }
}
