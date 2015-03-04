using System.Threading.Tasks;
using Newtonsoft.Json;
using ScheduleMyFood.Technical.Auth.Models;
using ScheduleMyFood.Technical.DependencyServices;

namespace ScheduleMyFood.Technical.Auth
{
    internal interface ITokenManager
    {
        Task<TokenResponseModel> GetSavedTokenResponseModelOrDefault();
        void SaveToken(TokenResponseModel tokenResponseModel);
    }

    class TokenManager : ITokenManager
    {
        private readonly ILocalStorageService _localStorageService;
        private string _filename;

        public TokenManager(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public async Task<TokenResponseModel> GetSavedTokenResponseModelOrDefault()
        {
            _filename = "oauth";
            var savedTokenResponseModelOrDefault = await Task.Run(()=>_localStorageService.LoadText(_filename));
            if (string.IsNullOrEmpty(savedTokenResponseModelOrDefault)) return null;
            return JsonConvert.DeserializeObject<TokenResponseModel>(savedTokenResponseModelOrDefault);
        }

        public async void SaveToken(TokenResponseModel tokenResponseModel)
        {
            var stringToken = JsonConvert.SerializeObject(tokenResponseModel);
            await Task.Run(()=>_localStorageService.SaveText(_filename, stringToken));
        }
    }
}
