using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;

namespace ADO.NET_HW5
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appSettings.json", false, true);
            IConfigurationRoot configurationRoot = builder.Build();
            var providerName = configurationRoot.GetSection("AppConfig").GetChildren().Single(item => item.Key == "ProviderName").Value;
            var connectionString = configurationRoot.GetConnectionString("MyConnectionString");

            DisconnectedLayer disconnectedLayer = new DisconnectedLayer(connectionString, providerName);
        }
    }
}
