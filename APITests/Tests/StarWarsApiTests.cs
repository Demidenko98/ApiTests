using NUnit.Framework;
using System;
using System.Threading;

namespace APITests
{
    public class StarWarsApiTests
    {

        [Test]
        public void CheckCountEquals61InResponse()
        {
            BaseApi baseApi = new BaseApi();
            baseApi.Get(URL.planetURL).Wait();
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
            baseApi.Get(URL.planetURL).Wait();
            baseApi.DeserealizePlanets();
            string firstPlanetURL = baseApi.GetFirstPlanetURLFromJson();
            baseApi.Get(firstPlanetURL).Wait();
            int expectedStatusCode = 200;
            int actualResponseCode = baseApi.CheckResponseCode();
            Assert.AreEqual(expectedStatusCode, actualResponseCode); // Check firstPlanetURL Response Code is 200
        }


        [Test]
        public void GetMovieName()
        {
            BaseApi baseApi = new BaseApi();
            baseApi.Get(URL.filmsURL).Wait();
            baseApi.DeserealizeMovies();
            string[] expectedMoviesNamesList = new string[]
         { "A New Hope",
            "The Empire Strikes Back",
            "Return of the Jedi",
            "The Phantom Menace",
            "Attack of the Clones",
            "Revenge of the Sith"
         };
            string[] actualMoviesNamesList = baseApi.GetAllMoviesName();
            Assert.AreEqual(expectedMoviesNamesList, actualMoviesNamesList); //Check the expectedMoviesNamesList corresponds to actualMoviesNamesList


        }
    }
}