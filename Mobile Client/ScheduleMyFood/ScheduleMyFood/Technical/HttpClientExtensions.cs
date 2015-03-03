using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ScheduleMyFood.Technical
{
    static class HttpClientExtensions
    {
        public static async Task<T> GetAsync<T>(this HttpClient client,string resourceName) where T : new()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, resourceName);
            return await client.SendRequest<T>(request);
        }
        public static async Task<TResponse> PostAsync<TRequest, TResponse>(this HttpClient client, string resourceName, TRequest resource) where TResponse : new()
        {
            var resourceAsString = JsonConvert.SerializeObject(resource);
            var request = new HttpRequestMessage(HttpMethod.Post, resourceName)
            {
                Content = new StringContent(resourceAsString, Encoding.UTF8, App.Constants.ApplicationJson)
            };
            return await client.SendRequest<TResponse>(request);
        }
        public static async Task<T> PostAsync<T>(this HttpClient client,string resourceName, T resource) where T : new()
        {
            return await client.PostAsync<T, T>(resourceName, resource);
        }
        internal static async Task<T> SendRequest<T>(this HttpClient client, HttpRequestMessage request) where T : new()
        {
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var value = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(value);
        }
        internal static void SetAuthenticationToken(this HttpClient client, string accessToken)
        {
            client.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));
        }
    }
}
