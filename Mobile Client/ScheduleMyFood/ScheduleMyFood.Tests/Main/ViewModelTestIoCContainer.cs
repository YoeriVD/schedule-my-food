using Autofac;
using Autofac.Core;

namespace ScheduleMyFood.Tests.Main
{
    class ViewModelTestIoCContainer
    {
        private static readonly IContainer Container;

        static ViewModelTestIoCContainer()
        {
            var builder = new ContainerBuilder();
            // Registers all modules
            builder
                .AddServiceMocks()
                .RegisterAssemblyTypes(typeof(App).Assembly)
                .Where(t => t.Name.EndsWith("ViewModel"))
                .AsImplementedInterfaces();
            Container = builder.Build();
        }

        public static T CreateTestSubject<T>(params Parameter[] parameters)
        {
            T sut;
            using (var scope = Container.BeginLifetimeScope())
            {
                sut = scope.Resolve<T>(parameters);
            }
            return sut;
        }
    }

    internal static class BuilderExtensions
    {
        internal static ContainerBuilder AddServiceMocks(this ContainerBuilder builder)
        {
            builder.RegisterInstance(ServiceMocks.RecipeProxy.Object);
            return builder;
        }
    }
}
