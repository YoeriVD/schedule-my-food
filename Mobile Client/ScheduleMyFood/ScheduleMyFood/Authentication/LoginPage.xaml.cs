using ScheduleMyFood.Recipes;
using Xamarin.Forms;

namespace ScheduleMyFood.Authentication
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage(ILoginViewModel loginViewModel, RecipePage nextPage)
        {
            InitializeComponent();
            loginViewModel.NavigateToRecipes = new Command(() =>this.Navigation.PushAsync(nextPage.Activate()));
            this.BindingContext = loginViewModel;
        }
    }
}
