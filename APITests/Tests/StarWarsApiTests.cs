using NUnit.Framework;
using System;
using System.Threading;

namespace APITests
{
    public class StarWarsApiTests
    {
       // [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CheckCountEquals61InResponse()
        {
            BaseApi baseApi = new BaseApi();
            baseApi.Get(URL.planetURL);
            Thread.Sleep(10000);
            baseApi.DeserealizePlanets();
            Console.WriteLine(baseApi.myDeserializedClassPlanets.Count);

            int expectedCount = 61;
            int actualCount = baseApi.myDeserializedClassPlanets.Count;
            Assert.AreEqual(expectedCount, actualCount); //Check that expected Count value corresponds to actualCount
        }


        [Test]
        public void FirstPlanetApiReturns200()
        {
            BaseApi baseApi = new BaseApi();
            baseApi.Get(URL.planetURL);
            Thread.Sleep(40000);
            baseApi.DeserealizePlanets();
            string firstPlanetURL = baseApi.GetFirstPlanetURLFromJson();
            baseApi.Get(firstPlanetURL);
            int expectedStatusCode = 200;
            int actualResponseCode = baseApi.CheckResponseCode();        
            Assert.AreEqual(expectedStatusCode, actualResponseCode); // Check Response Code is 200
        }


        [Test]
        public void GetMovieName()
        {
            BaseApi baseApi = new BaseApi();
            baseApi.Get(URL.filmsURL);
            Thread.Sleep(10000);
            baseApi.DeserealizeMovies();
            baseApi.GetAllMoviesName();
        }
    }
}