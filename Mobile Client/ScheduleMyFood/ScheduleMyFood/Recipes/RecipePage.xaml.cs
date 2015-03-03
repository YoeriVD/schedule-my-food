using System;
using ScheduleMyFood.Annotations;
using Xamarin.Forms;

namespace ScheduleMyFood.Recipes
{
    public partial class RecipePage : ContentPage
    {
        private readonly IMainViewModel _mainViewModel;

        public RecipePage([NotNull] IMainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            if (mainViewModel == null) throw new ArgumentNullException(nameof(mainViewModel));
            InitializeComponent();
        }

        internal RecipePage Activate()
        {
            this.BindingContext =_mainViewModel;
            return this;
        }
    }
}
