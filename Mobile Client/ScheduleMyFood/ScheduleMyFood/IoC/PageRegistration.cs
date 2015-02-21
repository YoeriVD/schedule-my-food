using Autofac;

namespace ScheduleMyFood.IoC
{
    class PageRegistration : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(t => t.Name.EndsWith("Page"))
                .AsSelf();
            base.Load(builder);
        }
    }
}