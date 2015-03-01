using Autofac;
using Autofac.Core;

namespace ScheduleMyFood.Tests.Proxies
{
    class ProxyTestIoCContainer
    {
        private static readonly IContainer Container;

        static ProxyTestIoCContainer()
        {
            var builder = new ContainerBuilder();
            // Registers all modules
            builder
                .RegisterAssemblyTypes(typeof(App).Assembly)
                .Where(t => t.Name.EndsWith("Proxy"))
                .AsImplementedInterfaces();

            builder.RegisterInstance(ServiceMocks.FoodHttpClient.Object);

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
}
