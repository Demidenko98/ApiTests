using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using APITests.Core;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace APITests.Tests
{
    class LoginTests
    {
        [Test]
        public void GetAuthorizationToken()
        {
            BaseApi baseApi = new BaseApi();    
            StringContent content = baseApi.SerealizeCredentials();    
            baseApi.Post(URL.loginURL,content).Wait(); 
            baseApi.DeserealizeLoginResponseToken();
            string expectedTokenValue = "QpwL5tke4Pnpja7X4";
            string actualTokenValue = baseApi.myDeserializedLoginResponse_token.token;
            // Console.WriteLine(baseApi.myDeserializedLoginResponse_token.token);  
          //  new ConfigController().ConnectToConfigJson();
            Assert.AreEqual(expectedTokenValue, actualTokenValue);  //Check response token corresponds expectedTokenValue
        }
    }
}
