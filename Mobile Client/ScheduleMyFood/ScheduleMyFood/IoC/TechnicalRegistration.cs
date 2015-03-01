using System.Net.Http;
using Autofac;

namespace ScheduleMyFood.IoC
{
    class TechnicalRegistration : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(t => t.Namespace.EndsWith("Technical"))
                .AsImplementedInterfaces();
            builder.RegisterType<HttpClient>().SingleInstance();
            base.Load(builder);
        }
    }
}
