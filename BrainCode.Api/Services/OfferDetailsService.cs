using BrainCode.Api.Helpers;
using BrainCode.Api.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BrainCode.Api.Services
{
    public class OfferDetailsService
    {
        private string _url = "https://api.natelefon.pl/v1/allegro/offers/";

        public async Task<OfferDetails> GetOfferDetails(string id)
        {
            Header bearerHeader = await BearerHelper.GetBearerHeader();

            List<Header> headers = new List<Header>()
            {
                new Header("User-Agent", "hackaton2017 (Client-Id 656cbe47-b17d-46c2-bae1-3222c8777d5b) Platform"),
                bearerHeader
            };

            HttpClient client = new HttpClient();

            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(_url + id),
                Method = HttpMethod.Get,
            };

            foreach (var header in headers)
            {
                request.Headers.Add(header.Name, header.Value);
            }

            var response = await client.SendAsync(request);
            string responseObject = await response.Content.ReadAsStringAsync();

            var responseJsonObject = (JObject)JsonConvert.DeserializeObject(responseObject);

            return CreateModel(responseJsonObject);
        }

        private OfferDetails CreateModel(JObject responseJsonObject)
        {
            OfferDetails result = new OfferDetails();

            var attributes = responseJsonObject["attributes"].AsJEnumerable();

            foreach (var attribute in attributes)
            {
                OfferDetailsAttribute attributeModel = new OfferDetailsAttribute()
                {
                    Name = attribute["name"].Value<string>(),
                    Attributes = attribute["values"].ToObject<List<string>>()
                };

                result.Attributes.Add(attributeModel);
            }

            var breadcrumbs = responseJsonObject["categories"]["breadcrumbs"].AsJEnumerable();

            foreach(var breadcrumb in breadcrumbs)
            {
                result.Categories.Add(new Category()
                {
                    Name = breadcrumb["name"].Value<string>(),
                    Id = breadcrumb["id"].Value<string>(),
                    Parent = breadcrumb["parent"].Value<string>()
                });
            }

            return result;
        }
    }
}
