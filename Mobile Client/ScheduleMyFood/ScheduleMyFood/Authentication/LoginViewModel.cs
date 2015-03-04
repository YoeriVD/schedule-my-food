using System;
using System.ComponentModel;
using System.IO;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ScheduleMyFood.Annotations;
using ScheduleMyFood.Technical;
using ScheduleMyFood.Technical.Auth;
using ScheduleMyFood.Technical.Auth.Models;
using Xamarin.Forms;

namespace ScheduleMyFood.Authentication
{
    public interface ILoginViewModel : INotifyPropertyChanged
    {
        string Email { get; set; }
        string Password { get; set; }
        ICommand PerformRegister { get; }
        ICommand PerformLogin { get; }
        ICommand NavigateToRecipes { get; set; }
        Action<string> ShowError { get; set; }
    }

    class LoginViewModel : ILoginViewModel
    {
        private readonly HttpClient _client;
        private readonly IAuthenticationClient _authenticationClient;
        private readonly ITokenManager _tokenManager;
        private bool _isBusy;
        public string Email { get; set; }
        public string Password { get; set; }

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        public ICommand PerformRegister => new Command(async () =>
        {
            IsBusy = true;
            await _authenticationClient.Register(Email, Password);
            PerformLogin.Execute(null);
        }, () => !IsBusy);

        public ICommand PerformLogin => new Command(async () =>
        {
            IsBusy = true;
            TokenResponseModel localToken = null;
            try
            {
                localToken = await _tokenManager.GetSavedTokenResponseModelOrDefault();
            }
            catch (FileNotFoundException)
            {/* do nothing (token does not yet exist) */}
            catch (Exception e)
            { ShowError(e.Message); }
            var token = localToken?.AccessToken ?? await _authenticationClient.GetTokenFromEndPoint(Email, Password);
            _client.SetAuthenticationToken(token);
            NavigateToRecipes.Execute(null);
        }, () => !IsBusy);

        public ICommand NavigateToRecipes { get; set; }
        public Action<string> ShowError { get; set; }

        public LoginViewModel(HttpClient client, IAuthenticationClient authenticationClient, ITokenManager tokenManager)
        {
#if DEBUG
            Email = "test@test.be";
            Password = "test123";
#endif
            _client = client;
            _authenticationClient = authenticationClient;
            _tokenManager = tokenManager;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
