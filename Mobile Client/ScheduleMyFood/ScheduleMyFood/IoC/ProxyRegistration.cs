using Autofac;

namespace ScheduleMyFood.IoC
{
    class ProxyRegistration : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(t => t.Name.EndsWith("Proxy"))
                .SingleInstance()
                .AsImplementedInterfaces();
            base.Load(builder);
        }
    }
}