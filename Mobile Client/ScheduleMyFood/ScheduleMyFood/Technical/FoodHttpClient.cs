using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ScheduleMyFood.Technical
{
    /// <summary>
    /// 
    /// </summary>
    public interface IFoodHttpClient
    {
        Task<T> GetAsync<T>(string url) where T : new();
        Task<T> PostAsync<T>(string resourceName, T resource) where T : new();
    }

    class FoodHttpClient : IFoodHttpClient
    {
        private readonly HttpClient _client;
        private readonly IWebApiExceptionHandler _exceptionHandler;

        public FoodHttpClient(HttpClient client, IWebApiExceptionHandler exceptionHandler)
        {
            _client = client;
            _exceptionHandler = exceptionHandler;
            _client.BaseAddress = new Uri("http://schedule-my-food.azurewebsites.net");
        }
        public async Task<T> GetAsync<T>(string url) where T : new()
        {
            var responseMessage = await _client.GetAsync(url);
            if (!responseMessage.IsSuccessStatusCode)
            {
                _exceptionHandler.Handle(responseMessage);
                return default(T);
            }
            var value = await responseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(value);
        }
        public async Task<T> PostAsync<T>(string resourceName, T resource) where T : new()
        {
            var resourceAsString = JsonConvert.SerializeObject(resource);
            var response = await _client.PostAsync(resourceName, new StringContent(resourceAsString));
            if (!response.IsSuccessStatusCode)
            {
                _exceptionHandler.Handle(response);
            }
            var value = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(value);
        }
    }
}
