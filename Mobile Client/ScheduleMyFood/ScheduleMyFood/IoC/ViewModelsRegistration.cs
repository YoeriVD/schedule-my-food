

using Autofac;

namespace ScheduleMyFood.IoC
{
    class ViewModelsRegistration : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(t => t.Name.EndsWith("ViewModel"))
                .AsImplementedInterfaces();
            base.Load(builder);
        }
    }
}
