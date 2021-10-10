using APITests.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace APITests.Core
{
    class ConfigController
    {
        public static Credentials credentials = new Credentials();

        public static string ConfigurationFilreRead(string getValueFromConfigJson)
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(@"D:\papka\AQA\APITests\APITests\Configuration\configsetting.json");
            IConfigurationRoot configuration = builder.Build();
            configuration.Bind(credentials);
            var valueFromJson = configuration.GetValue<string>(getValueFromConfigJson);
            return valueFromJson;
        }

        public void ConnectToConfigJson(string getValueFromConfigJson)   //сделал два способа считывания конфиг джсона
        {
            string jsonString = System.IO.File.ReadAllText(@"D:\papka\AQA\APITests\APITests\Configuration\configsetting.json");
            Credentials credentials = JsonConvert.DeserializeObject<Credentials>(jsonString);
         //   getValueFromConfigJson = credentials.email;
            Console.WriteLine(credentials.email);
            Console.WriteLine(credentials.password);    
        }

      

       
    }
}
