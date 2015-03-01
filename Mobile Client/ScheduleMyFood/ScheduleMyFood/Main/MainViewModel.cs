using System.Collections.ObjectModel;
using ScheduleMyFood.Proxies;
using SharedSchema;

namespace ScheduleMyFood.Main
{
    public interface IMainViewModel
    {
        IRecipeProxy RecipeProxy { get; }
    }

    class MainViewModel : IMainViewModel
    {
        public IRecipeProxy RecipeProxy { get; private set; }

        public MainViewModel(IRecipeProxy recipeProxy)
        {
            RecipeProxy = recipeProxy;
        }
    }
}
