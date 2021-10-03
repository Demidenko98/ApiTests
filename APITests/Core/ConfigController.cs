using APITests.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace APITests.Core
{
    class ConfigController
    {
        public Credentials credentials = new Credentials();

        private IConfiguration Configuration;
        public ConfigController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigurationFilreRead()
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(@"D:\papka\AQA\APITests\APITests\Configuration\configsetting.json");
            IConfigurationRoot configuration = builder.Build();
            configuration.Bind(credentials);
        }

        public void ShowDataFromJsonConfig()
        {
            credentials.email = Configuration.GetValue<string>("email");
            Console.WriteLine(credentials.email);
        }
    }
}
