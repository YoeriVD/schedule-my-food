using System.Runtime.CompilerServices;
using System.ServiceModel.Channels;
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
            loginViewModel.ShowError = message => DisplayAlert("Something went wrong!", message, "Got it!");
            this.BindingContext = loginViewModel;
        }
    }
}
