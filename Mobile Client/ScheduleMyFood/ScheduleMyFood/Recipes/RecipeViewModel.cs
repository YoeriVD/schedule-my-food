using ScheduleMyFood.Proxies;

namespace ScheduleMyFood.Recipes
{
    public interface IMainViewModel
    {
        IRecipeProxy RecipeProxy { get; }
    }

    class RecipeViewModel : IMainViewModel
    {
        public IRecipeProxy RecipeProxy { get; private set; }

        public RecipeViewModel(IRecipeProxy recipeProxy)
        {
            RecipeProxy = recipeProxy;
        }
    }
}
