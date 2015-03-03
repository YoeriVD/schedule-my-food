using System.Net.Http;
using System.Windows.Input;
using ScheduleMyFood.Technical;
using ScheduleMyFood.Technical.Auth;
using Xamarin.Forms;

namespace ScheduleMyFood.Authentication
{
    public interface ILoginViewModel
    {
        string Email { get; set; }
        string Password { get; set; }
        ICommand PerformRegister { get;  }
        ICommand PerformLogin { get;  }
        ICommand NavigateToRecipes { get; set; }
    }

    class LoginViewModel : ILoginViewModel
    {
        private readonly HttpClient _client;
        private readonly IAuthenticationClient _authenticationClient;
        public string Email { get; set; }
        public string Password { get; set; }

        public ICommand PerformRegister => new Command(async () =>
        {
            await _authenticationClient.Register(Email, Password);
            PerformLogin.Execute(null);
        });

        public ICommand PerformLogin => new Command(async () =>
        {
            var token = await _authenticationClient.GetTokenFromEndPoint(Email, Password);
            _client.SetAuthenticationToken(token);
            NavigateToRecipes.Execute(null);
        });

        public ICommand NavigateToRecipes { get; set; }

        public LoginViewModel(HttpClient client, IAuthenticationClient authenticationClient)
        { 
#if DEBUG
            Email = "test@test.be";
            Password = "test123";
#endif
            _client = client;
            _authenticationClient = authenticationClient;
        }
    }
}
