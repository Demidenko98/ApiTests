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

namespace APITests
{
    class BaseApi
    {
        
        HttpClient httpClient = new HttpClient();
        HttpResponseMessage response = new HttpResponseMessage();
        string responseBody;
        public RootJsonPlanets myDeserializedClassPlanets = new RootJsonPlanets();
        public RootJsonMovies myDeserializedClassMovies = new RootJsonMovies();
        public TokenClass myDeserializedLoginResponse_token = new TokenClass();


        
        public async void Get(string url)
        {
            
            response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            responseBody = await response.Content.ReadAsStringAsync();
        }

        public async void Post(string URL, HttpContent content)
        {
            response = await httpClient.PostAsync(URL,content);
            response.EnsureSuccessStatusCode();
            responseBody = response.Content.ReadAsStringAsync().Result;
        }

        public StringContent SerealizeCredentials()
        {
            Credentials credentials = new Credentials 
            {
                email= "eve.holt@reqres.in",
                password = "cityslicka"
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
            myDeserializedClassPlanets = JsonConvert.DeserializeObject<RootJsonPlanets>(responseBody);
        }

        public void DeserealizeMovies()
        {
            myDeserializedClassMovies = JsonConvert.DeserializeObject<RootJsonMovies>(responseBody);
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

        public void GetAllMoviesName()
        {
            foreach (var item in myDeserializedClassMovies.Results)
            {
                Console.WriteLine(item.Title);
            }
        }
    }
}
