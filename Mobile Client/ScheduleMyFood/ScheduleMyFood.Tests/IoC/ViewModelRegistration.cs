using Autofac;

namespace ScheduleMyFood.Tests.IoC
{
    class ViewModelRegistration : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(App).Assembly)
                .Where(t => t.Name.EndsWith("ViewModel"))
                .AsImplementedInterfaces();
            base.Load(builder);
        }
    }
}
