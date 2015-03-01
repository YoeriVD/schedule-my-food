using System.Net.Http;

namespace ScheduleMyFood.Technical
{
    internal interface IWebApiExceptionHandler
    {
        void Handle(HttpResponseMessage response);
    }

    class WebApiExceptionHandler : IWebApiExceptionHandler
    {
        public void Handle(HttpResponseMessage response)
        {
            response.EnsureSuccessStatusCode();
        }
    }
}
