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
           
            baseApi.Post(URL.loginURL,content);
            Thread.Sleep(15000);
            baseApi.DeserealizeLoginResponseToken();
            Console.WriteLine(baseApi.myDeserializedLoginResponse_token.token);       
        }
    }
}
