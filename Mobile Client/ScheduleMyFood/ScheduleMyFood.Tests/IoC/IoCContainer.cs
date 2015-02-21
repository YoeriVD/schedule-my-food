using Autofac;

namespace ScheduleMyFood.Tests.IoC
{
    class IoCContainer
    {
        private static readonly IContainer Container;

        static IoCContainer()
        {
            var builder = new ContainerBuilder();
            // Registers all modules
            builder.RegisterAssemblyModules(typeof(IoCContainer).Assembly);
            Container = builder.Build();
        }

        public static T CreateTestSubject<T>()
        {
            T sut;
            using (var scope = Container.BeginLifetimeScope())
            {
                sut = scope.Resolve<T>();
            }
            return sut;
        }

    }
}
