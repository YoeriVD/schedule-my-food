using Moq;
using ScheduleMyFood.Proxies;
using ScheduleMyFood.Technical;

namespace ScheduleMyFood.Tests
{
    static class ServiceMocks
    {
        internal static Mock<IRecipeProxy> RecipeProxy { get; private set; }
        internal static Mock<IFoodHttpClient> FoodHttpClient { get; private set; }

        static ServiceMocks()
        {
            RecipeProxy = new Mock<IRecipeProxy>();
            FoodHttpClient = new Mock<IFoodHttpClient>();
        }
    }
}
