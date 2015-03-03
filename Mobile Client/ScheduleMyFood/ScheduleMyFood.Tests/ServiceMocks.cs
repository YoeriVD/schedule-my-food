using Moq;
using ScheduleMyFood.Proxies;

namespace ScheduleMyFood.Tests
{
    static class ServiceMocks
    {
        internal static Mock<IRecipeProxy> RecipeProxy { get; private set; }

        static ServiceMocks()
        {
            RecipeProxy = new Mock<IRecipeProxy>();
        }
    }
}
