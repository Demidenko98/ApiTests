using APITests.Core;
using APITests.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace APITests
{
    class BaseApi
    {
        
        HttpClient httpClient = new HttpClient();
        HttpResponseMessage response = new HttpResponseMessage();
        string responseBody;
        public DeserializedJsonPlanets myDeserializedClassPlanets = new DeserializedJsonPlanets();
        public DeserializedJsonMovies myDeserializedClassMovies = new DeserializedJsonMovies();
        public TokenClass myDeserializedLoginResponse_token = new TokenClass();


        
        public async Task<HttpResponseMessage> Get(string url)
        {
            response =  await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            responseBody = await response.Content.ReadAsStringAsync();
            return response;
        }

      
        public async Task<HttpResponseMessage> Post(string URL, HttpContent content)
        {
            response = await httpClient.PostAsync(URL,content);
            response.EnsureSuccessStatusCode();
            responseBody = await response.Content.ReadAsStringAsync();
            return response;
        }

        public StringContent SerealizeCredentials()
        {
            Credentials credentials = new Credentials 
            {
                email = ConfigController.ConfigurationFilreRead("email"),
                password = ConfigController.ConfigurationFilreRead("password")
            };
     
            string json = JsonConvert.SerializeObject(credentials, Formatting.Indented);
            StringContent data = new StringContent(json, Encoding.UTF8, "application/json");
           
            return data;
            
        }

        public void DeserealizeLoginResponseToken()
        {
            myDeserializedLoginResponse_token = JsonConvert.DeserializeObject<TokenClass>(responseBody);
        }

        public void DeserealizePlanets()
        {
            myDeserializedClassPlanets = JsonConvert.DeserializeObject<DeserializedJsonPlanets>(responseBody);
        }

        public void DeserealizeMovies()
        {
            myDeserializedClassMovies = JsonConvert.DeserializeObject<DeserializedJsonMovies>(responseBody);
        }

        public string GetFirstPlanetURLFromJson()
        {
            string firstPlanetURL = null;
            for (int i = 0; i < myDeserializedClassPlanets.Results.Count; i++)
            {
                firstPlanetURL = myDeserializedClassPlanets.Results[0].Url;               
            }
            return firstPlanetURL;
        }

        public int CheckResponseCode()
        {
            if ((int)response.StatusCode == 200)
                return 200;
            else
                return 0;
        }

        public string[] GetAllMoviesName()
        {
            string[] allMoviesName = new string[myDeserializedClassMovies.Results.Count];
            for (int i=0; i<myDeserializedClassMovies.Results.Count;i++)
            {
                allMoviesName[i] = myDeserializedClassMovies.Results[i].Title;
                Console.WriteLine(allMoviesName[i]);
            }

            return allMoviesName;

        }
    }
}
