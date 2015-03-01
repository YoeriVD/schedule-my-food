using Autofac;
using FluentAssertions;
using NUnit.Framework;
using ScheduleMyFood.IoC;
using ScheduleMyFood.Proxies;
using ScheduleMyFood.Technical;

namespace ScheduleMyFood.Tests.IoC
{
    [TestFixture()]
    public class AppContainerTests
    {
        private ILifetimeScope _sut;

        [TestFixtureSetUp]
        public void Setup()
        {
            _sut = new AppContainer().CreateContainer().BeginLifetimeScope();
        }

        [TestFixtureTearDown]
        public void CleanUp()
        {
            _sut.Dispose();
        }
        [Test]
        public void Container_should_be_able_to_resolve_FoodHttpClient()
        {
            _sut.Resolve<IFoodHttpClient>().Should().NotBeNull();
        }

        [Test]
        public void Container_should_be_able_to_resolve_RecipeProxy()
        {
            _sut.Resolve<IRecipeProxy>().Should().NotBeNull();
        }
    }
}
