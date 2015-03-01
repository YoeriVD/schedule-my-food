using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using ScheduleMyFood.Proxies;
using SharedSchema;

namespace ScheduleMyFood.Tests.Proxies
{
    [TestFixture]
    class RecipeProxyTests
    {
        private IRecipeProxy _sut;

        [TestFixtureSetUp]
        public void SetUp()
        {
            _sut = ProxyTestIoCContainer.CreateTestSubject<IRecipeProxy>();
        }

        [Test]
        public void RecipeProxy_should_be_able_to_get_all_recipes()
        {
            List<Recipe> testCollection = new List<Recipe>()
            {
                new Recipe() {Name = "Test1"},
                new Recipe() {Name = "Test2"},
                new Recipe() {Name = "Test3"}
            };
            ServiceMocks.FoodHttpClient
                .Setup(client => client.GetAsync<List<Recipe>>("recipes"))
                .ReturnsAsync(testCollection);

            _sut.Get().Result.Should().BeSameAs(testCollection);

            ServiceMocks.FoodHttpClient
                .Verify(client => client.GetAsync<List<Recipe>>("recipes"), Times.AtMostOnce);
        }

        [Test]
        public void RecipeProxy_should_be_able_to_keep_a_local_copy_of_recipes()
        {
            List<Recipe> testCollection = new List<Recipe>()
            {
                new Recipe() {Name = "Test1"},
                new Recipe() {Name = "Test2"},
                new Recipe() {Name = "Test3"}
            };
            ServiceMocks.FoodHttpClient
                .Setup(client => client.GetAsync<List<Recipe>>("recipes"))
                .ReturnsAsync(testCollection);
            _sut.MonitorEvents();
            var dummy = _sut.LocalCollection;
            _sut.ShouldRaisePropertyChangeFor(m => m.LocalCollection);
            _sut.LocalCollection.ShouldAllBeEquivalentTo(testCollection);
        }
    }
}
