﻿using BrainCode.Api.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BrainCode.Api.Services
{
    public class BearerService
    {
        private string _url = "https://ssl.allegro.pl/auth/oauth/token?grant_type=client_credentials";

        private List<Header> _headers = new List<Header>()
        {
            new Header("Authorization", "Basic YTQxZjViMmEtOGU4Ny00YjhiLWI2ZmUtNzRjYzc2MzcyMGQ3OmJ4YmIyZ0ZxQ1AxYU0za05QZXB0QVdRTUd6OWdvc2JlOUpDTzFzcWxwMEJoWTlHNFV1ZnBrWGdzU0ZRWUU1NDU=")
        };
        
        public async Task<Header> GetBearerHeader()
        {
            string access_token = await GetBearerToken();
            return new Header("Authorization", string.Format("Bearer {0}", access_token));
        }
       
        private async Task<string> GetBearerToken()
        {
            HttpClient client = new HttpClient();

            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(_url),
                Method = HttpMethod.Get,
            };

            foreach(var header in _headers)
            {
                request.Headers.Add(header.Name, header.Value);
            }

            var response = await client.SendAsync(request);
            string responseObject = await response.Content.ReadAsStringAsync();

            var responseJsonObject = (JObject)JsonConvert.DeserializeObject(responseObject);

            return responseJsonObject["access_token"].Value<string>();
        }
    }
}
