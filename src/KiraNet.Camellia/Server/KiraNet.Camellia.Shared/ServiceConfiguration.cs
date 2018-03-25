using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace KiraNet.Camellia.Shared
{
    public class ServiceConfiguration
    {
        private static Lazy<ServiceConfiguration> _instance = new Lazy<ServiceConfiguration>(()=> new ServiceConfiguration());

        public static ServiceConfiguration Configs => _instance.Value;

        private IConfigurationRoot _Configuration;
        private ServiceConfiguration()
        {
               var builder = new ConfigurationBuilder()
                //.SetBasePath(@"C:\Users\99752\Desktop\KiraNet.Camellia\Server\KiraNet.Camellia.Shared")
                .SetBasePath(Directory.GetParent(System.Reflection.Assembly.GetEntryAssembly().Location).FullName)
                .AddJsonFile("settings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
            _Configuration = builder.Build();
        }

        public string ServiceName => _Configuration["ServiceSettings:ServiceName"];
        public string ServiceDisplay => _Configuration["ServiceSettings:ServiceDisplay"];
        public string AuthId => _Configuration["Services:Authorization:AuthId"];
        public string AuthName => _Configuration["Services:Authorization:AuthName"];
        public string AuthBase => _Configuration["Services:Authorization:AuthBase"];
        public string ApiId => _Configuration["Services:Api:ClientId"];
        public string ApiName=> _Configuration["Services:Api:ClientName"];
        public string ApiBase => _Configuration["Services:Api:ClientBase"];
        public string ClientId => _Configuration["Services:Client:ClientId"];
        public string ClientName => _Configuration["Services:Client:ClientName"];
        public string ClientBase => _Configuration["Services:Client:ClientBase"];

    }
}
