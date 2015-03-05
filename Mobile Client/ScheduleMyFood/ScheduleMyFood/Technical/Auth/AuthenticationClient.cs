using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ScheduleMyFood.Technical.Auth.Models;

namespace ScheduleMyFood.Technical.Auth
{
    internal interface IAuthenticationClient
    {
        Task Register(string email, string password);
        Task<string> GetTokenFromEndPoint(string email, string password);
    }

    class AuthenticationClient : IAuthenticationClient
    {
        private readonly HttpClient _client;

        public AuthenticationClient(HttpClient client)
        {
            _client = client;
        }

        public async Task Register(string email, string password)
        {
            var model = new RegisterModel { Email = email, Password = password, ConfirmPassword = password };
            await _client.PostAsync("api/account/register", model);
        }

        public async Task<string> GetTokenFromEndPoint(string email, string password)
        {
            const string grantType = "password";
            HttpContent requestContent = new StringContent(string.Format("username={0}&password={1}&grant_type={2}"
                , WebUtility.HtmlEncode(email), WebUtility.HtmlEncode(password), grantType), Encoding.UTF8, "application/x-www-form-urlencoded");

            var response = await _client.PostAsync("Token", requestContent);
            response.EnsureSuccessStatusCode();
            string jsonMessage;
            using (var responseStream = await response.Content.ReadAsStreamAsync())
            {
                jsonMessage = new StreamReader(responseStream).ReadToEnd();
            }
            var tokenResponse = (TokenResponseModel)JsonConvert.DeserializeObject(jsonMessage, typeof(TokenResponseModel));
            return tokenResponse.AccessToken;
        }
    }
}
