using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Autofac;

namespace ScheduleMyFood.IoC
{
    class TechnicalRegistration : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(t => t.Namespace.Contains("Technical"))
                .AsImplementedInterfaces();
            builder.Register(c =>
            {
                var client = new HttpClient {BaseAddress = new Uri(App.Constants.BaseUrl)};
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(App.Constants.ApplicationJson));
                return client;
            }).SingleInstance();
            base.Load(builder);
        }
    }
}
